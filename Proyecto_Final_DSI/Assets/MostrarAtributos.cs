using UnityEngine;
using UnityEngine.UIElements;

public class MostrarAtributos : MonoBehaviour
{
    public UIDocument uiDocument;

    void OnEnable()
    {
        if (uiDocument == null)
        {
            Debug.LogError("El UIDocument no está asignado. Asigna el UIDocument en el Inspector.");
            return;
        }

        var visualTree = Resources.Load<VisualTreeAsset>("lab4d");
        if (visualTree == null)
        {
            Debug.LogError("El archivo UXML no se pudo cargar. Revisa la ruta.");
            return;
        }

        var root = uiDocument.rootVisualElement;

        // Limpiar los elementos existentes
        root.Clear();

        // Instanciar y agregar el nuevo UXML
        root.Add(visualTree.Instantiate());
    }

}

//public class InstanciadorAtributos : MonoBehaviour
//{
//    public UIDocument uiDocument; // Referencia al UIDocument

//    void Start()
//    {
//        var root = uiDocument.rootVisualElement;

//        // Crear primera instancia con el caballero1
//        var atributo1 = new lab4d();
//        atributo1.SetNombre("Defensa");
//        atributo1.Nivel = 3;
//        atributo1.Imagen = "escudo";
//        atributo1.SetCaballero("caballero1");  // Caballero 1
//        root.Add(atributo1);

//        // Crear segunda instancia con el caballero2
//        var atributo2 = new lab4d();
//        atributo2.SetNombre("Velocidad");
//        atributo2.Nivel = 4;
//        atributo2.Imagen = "zapato";
//        atributo2.SetCaballero("caballero2");  // Caballero 2
//        root.Add(atributo2);
//    }
//}
