using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class CambioPersonajes : MonoBehaviour
{
    Button izdaMorado;
    Button izdaNaranja;
    Button izdaAmarillo;
    Button dchaMorado;
    Button dchaNaranja;
    Button dchaAmarillo;

    VisualElement robot_amarillo;
    VisualElement robot_rojo;
    VisualElement robot_azul;
    VisualElement menu_amarillo;
    VisualElement menu_naranja;
    VisualElement menu_morado;

    [SerializeField]
    MenuPestanyas menuP;

    private void NoContenido()
    {
        menu_amarillo.style.display = DisplayStyle.None;
        menu_naranja.style.display = DisplayStyle.None;
        menu_morado.style.display = DisplayStyle.None;
        robot_azul.style.display = DisplayStyle.None;
        robot_amarillo.style.display = DisplayStyle.None;
        robot_rojo.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        VisualElement contenedor = rootve.Q("ROBOT");


        robot_azul = contenedor.Q("RobotAzul");
        robot_amarillo = contenedor.Q("RobotAmarillo");
        robot_rojo = contenedor.Q("RobotRojo");

        izdaMorado = robot_azul.Q<Button>("Izda");
        izdaAmarillo = robot_amarillo.Q<Button>("Izda");
        izdaNaranja = robot_rojo.Q<Button>("Izda");

        dchaMorado = robot_azul.Q<Button>("Dcha");
        dchaAmarillo = robot_amarillo.Q<Button>("Dcha");
        dchaNaranja = robot_rojo.Q<Button>("Dcha");

        menu_amarillo = contenedor.Q("MenuAmarillo");
        menu_naranja = contenedor.Q("MenuNaranja");
        menu_morado = contenedor.Q("MenuMorado");

        izdaMorado.clicked += () =>
        {
            NoContenido();
            robot_amarillo.style.display = DisplayStyle.Flex;
        };

        izdaNaranja.clicked += () =>
        {
            NoContenido();
            robot_azul.style.display = DisplayStyle.Flex;
        };

        izdaAmarillo.clicked += () =>
        {
            NoContenido();
            robot_rojo.style.display = DisplayStyle.Flex;
        };

        dchaMorado.clicked += () =>
        {
            NoContenido();
            robot_rojo.style.display = DisplayStyle.Flex;
        };

        dchaNaranja.clicked += () =>
        {
            NoContenido();
            robot_amarillo.style.display = DisplayStyle.Flex;
        };

        dchaAmarillo.clicked += () =>
        {
            NoContenido();
            robot_azul.style.display = DisplayStyle.Flex;
        };

        robot_azul.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            menu_morado.style.display = DisplayStyle.Flex;
            menuP.contPestanyaAzul();
        });

        robot_amarillo.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            menu_amarillo.style.display = DisplayStyle.Flex;
            menuP.contPestanyaAmarillo();
        });

        robot_rojo.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            menu_naranja.style.display = DisplayStyle.Flex;
            menuP.contPestanyaNaranja();
        });
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu_amarillo.resolvedStyle.display == DisplayStyle.Flex)
            {
                NoContenido();
                robot_amarillo.style.display = DisplayStyle.Flex;
            }
            else if (menu_morado.resolvedStyle.display == DisplayStyle.Flex)
            {
                NoContenido();
                robot_azul.style.display = DisplayStyle.Flex;
            }
            else if (menu_naranja.resolvedStyle.display == DisplayStyle.Flex)
            {
                NoContenido();
                robot_rojo.style.display = DisplayStyle.Flex;
            }
        }
    }
}
