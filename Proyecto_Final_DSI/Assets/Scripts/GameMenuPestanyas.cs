using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class GameMenuPestanyas : MonoBehaviour
{
    VisualElement button_characters;
    VisualElement button_game;
    VisualElement pestanya_characters;
    VisualElement pestanya_game;

    Button ajustes;
    Button exitAjustes;
    VisualElement ajustesWindow;

    private string savePath;
    private List<Individuo> individuos;
    private void NoContenido()
    {
        pestanya_characters.style.display = DisplayStyle.None;
        pestanya_game.style.display = DisplayStyle.None;
        ajustesWindow.style.display = DisplayStyle.None;
    }

    private string ObtenerImagenSegunNombre(string nombre)
    {
        if (string.IsNullOrEmpty(nombre))
            return "Skils1";

        // Obtener último carácter
        char ultimoChar = nombre[nombre.Length - 1];

        if (char.IsDigit(ultimoChar))
        {
            int num = int.Parse(ultimoChar.ToString());

            if (num <= 1) { return "Skils1"; }
            else if (num == 2) { return "Skils2"; }
            else if (num >= 3) { return "Skils3"; }
        }

        // Si no termina en número
        return "Skils1";
    }

    private void CargarImagenEnElemento(VisualElement target, string nombreImagen)
    {
        Texture2D tex = Resources.Load<Texture2D>($"Imagenes/{nombreImagen}");
        if (tex != null)
        {
            target.style.backgroundImage = new StyleBackground(tex);
        }
        else
        {
            Debug.LogWarning($"No se encontró la imagen: {nombreImagen}");
        }
    }

    private string ObtenerNombreSinNumero(string nombre)
    {
        // Buscar si hay un número al final
        int index = nombre.Length - 1;
        while (index >= 0 && char.IsDigit(nombre[index]))
        {
            index--;
        }

        // Extraer el nombre sin el número
        return nombre.Substring(0, index + 1);
    }

    private void OnEnable()
    {
        Debug.Log(Application.persistentDataPath);
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        VisualElement button = rootve.Q("BelowButtons");
        VisualElement pestanya = rootve.Q("Content");

        pestanya_characters = pestanya.Q("MenuInicial");
        pestanya_game = pestanya.Q("InitialMenu");

        button_characters = button.Q("Characters");
        button_game = button.Q("Game");

        ajustes = pestanya_game.Q<Button>("Ajustes");
        ajustesWindow = pestanya.Q("AjustesWindow");
        exitAjustes = ajustesWindow.Q<Button>("Exit");

        TextField nameInput = rootve.Q<TextField>("Username");
        Button saveButton = rootve.Q<Button>("SaveButton");
        Button changeButton = rootve.Q<Button>("ChangeUsernameButton");
        Label nameLabel = rootve.Q<Label>("NameLabel");
        VisualElement imagenUsuario = rootve.Q<VisualElement>("ProfilePicture");

        savePath = Path.Combine(Application.persistentDataPath, "individuos.json");

        exitAjustes.clicked += () =>
                {
                    NoContenido();
                    pestanya_game.style.display = DisplayStyle.Flex;
                };

        ajustes.clicked += () =>
        {
            NoContenido();
            ajustesWindow.style.display = DisplayStyle.Flex;
        };

        button_characters.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            pestanya_characters.style.display = DisplayStyle.Flex;
            imagenUsuario.style.display = DisplayStyle.None;
        });

        button_game.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            imagenUsuario.style.display = DisplayStyle.Flex;
            pestanya_game.style.display = DisplayStyle.Flex;
        });

        changeButton.clicked += () =>
        {
            nameLabel.style.display = DisplayStyle.None;
            changeButton.style.display = DisplayStyle.None;
            NoContenido();

            nameInput.style.display = DisplayStyle.Flex;
            saveButton.style.display = DisplayStyle.Flex;
        };

        saveButton.clicked += () =>
        {
            string nombre = nameInput.value;

            string imagenAsignada = ObtenerImagenSegunNombre(nombre);
            nombre = ObtenerNombreSinNumero(nombre);
            Individuo nuevo = new Individuo(nombre, imagenAsignada); // o deja "" si no quieres imagen
            CargarImagenEnElemento(imagenUsuario, imagenAsignada);

            individuos = new List<Individuo> { nuevo };
            string json = JsonHelperIndividuo.ToJson(individuos, true);
            File.WriteAllText(savePath, json);

            // Cambiar la UI
            nameInput.style.display = DisplayStyle.None;
            saveButton.style.display = DisplayStyle.None;
            nameLabel.text = $"{nuevo.Username}";
            nameLabel.style.display = DisplayStyle.Flex;
            changeButton.style.display = DisplayStyle.Flex;
            pestanya_game.style.display = DisplayStyle.Flex;

        };

        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            individuos = JsonHelperIndividuo.FromJson<Individuo>(json);

            if (individuos != null && individuos.Count > 0)
            {
                // Ya hay un individuo guardado
                nameInput.style.display = DisplayStyle.None;
                saveButton.style.display = DisplayStyle.None;

                nameLabel.text = $"{individuos[0].Username}";
                CargarImagenEnElemento(imagenUsuario, individuos[0].Imagen);
                nameLabel.style.display = DisplayStyle.Flex;
                changeButton.style.display = DisplayStyle.Flex;
                pestanya_game.style.display = DisplayStyle.Flex;
            }
            return;
        }

        NoContenido();
        nameInput.style.display = DisplayStyle.Flex;
        saveButton.style.display = DisplayStyle.Flex;
    }
}
