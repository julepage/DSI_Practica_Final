using UnityEngine;
using UnityEngine.UIElements;

public class lab4d : VisualElement
{
    Label nombreLabel = new Label();
    VisualElement iconosContainer = new VisualElement();

    int nivel;
    public int Nivel
    {
        get => nivel;
        set
        {
            nivel = Mathf.Clamp(value, 0, 5);
            ActualizarIconos();
        }
    }

    private string imagen;
    public string Imagen
    {
        get => imagen;
        set
        {
            imagen = value;
            ActualizarIconos();  // Hay que reconstruir los iconos cuando cambia la imagen también
        }
    }

    void ActualizarIconos()
    {
        iconosContainer.Clear();

        Texture2D texture = Resources.Load<Texture2D>("Imagenes/" + imagen);
        if (texture == null)
        {
           // Debug.LogError("No se pudo cargar la imagen: Imagenes/" + imagen);
            return;
        }

        for (int i = 0; i < 5; i++)
        {
            var icono = new VisualElement();
            icono.style.backgroundImage = new StyleBackground(texture);
            icono.style.width = 16;    // Tamaño más pequeño que antes (ajustable)
            icono.style.height = 16;
            icono.style.marginRight = 2;

            if (i >= nivel)
            {
                icono.style.opacity = 0.3f;  // Transparente si no está activo
            }
            else
            {
                icono.style.opacity = 1.0f;
            }

            iconosContainer.Add(icono);
        }
    }

    public void SetNombre(string nombre)
    {
        nombreLabel.text = nombre;
    }

    public lab4d()
    {
        style.display = DisplayStyle.Flex;
        style.flexDirection = FlexDirection.Column;
        style.alignItems = Align.Center;

        iconosContainer.style.flexDirection = FlexDirection.Row;

        hierarchy.Add(nombreLabel);
        hierarchy.Add(iconosContainer);
    }

    public new class UxmlFactory : UxmlFactory<lab4d, UxmlTraits> { }

    public new class UxmlTraits : VisualElement.UxmlTraits
    {
        UxmlIntAttributeDescription nivelAttr = new UxmlIntAttributeDescription { name = "nivel", defaultValue = 0 };
        UxmlStringAttributeDescription imagenAttr = new UxmlStringAttributeDescription { name = "imagen" };
        UxmlStringAttributeDescription nombreAttr = new UxmlStringAttributeDescription { name = "nombre", defaultValue = "Atributo" };

        public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
        {
            base.Init(ve, bag, cc);
            var atributo = ve as lab4d;

            atributo.Nivel = nivelAttr.GetValueFromBag(bag, cc);
            atributo.Imagen = imagenAttr.GetValueFromBag(bag, cc);
            atributo.SetNombre(nombreAttr.GetValueFromBag(bag, cc));
        }
    }
}
