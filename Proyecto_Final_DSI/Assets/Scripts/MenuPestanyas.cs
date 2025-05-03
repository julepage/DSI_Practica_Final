using UnityEngine;
using UnityEngine.UIElements;

public class MenuPestanyas : MonoBehaviour
{
    VisualElement contenido_azulMorado;
    VisualElement contenido_verdeMorado;
    VisualElement pestanya_azulMorado;
    VisualElement pestanya_verdeMorado;
    VisualElement contenido_azulNaranja;
    VisualElement contenido_verdeNaranja;
    VisualElement pestanya_azulNaranja;
    VisualElement pestanya_verdeNaranja;
    VisualElement contenido_azulAmarillo;
    VisualElement contenido_verdeAmarillo;
    VisualElement pestanya_azulAmarillo;
    VisualElement pestanya_verdeAmarillo;

    public void contPestanyaAzul()
    {
        NoContenido();
        contenido_azulMorado.style.display = DisplayStyle.Flex;
    }

    public void contPestanyaAmarillo()
    {
        NoContenido();
        contenido_azulAmarillo.style.display = DisplayStyle.Flex;
    }

    public void contPestanyaNaranja()
    {
        NoContenido();
        contenido_azulNaranja.style.display = DisplayStyle.Flex;
    }
    private void NoContenido()
    {
        contenido_azulMorado.style.display = DisplayStyle.None;
        contenido_verdeMorado.style.display = DisplayStyle.None;
        contenido_azulNaranja.style.display = DisplayStyle.None;
        contenido_verdeNaranja.style.display = DisplayStyle.None;
        contenido_azulAmarillo.style.display = DisplayStyle.None;
        contenido_verdeAmarillo.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
        UIDocument uidoc = GetComponent<UIDocument>();
        VisualElement rootve = uidoc.rootVisualElement;

        VisualElement menuMorado = rootve.Q("MenuMorado");
        VisualElement menuNaranja = rootve.Q("MenuNaranja");
        VisualElement menuAmarillo = rootve.Q("MenuAmarillo");

        VisualElement contenidoMorado = menuMorado.Q("Contenido");
        VisualElement pestanyasMorado = menuMorado.Q("Pestanyas");
        VisualElement contenidoNaranja = menuNaranja.Q("Contenido");
        VisualElement pestanyasNaranja = menuNaranja.Q("Pestanyas");
        VisualElement contenidoAmarillo = menuAmarillo.Q("Contenido");
        VisualElement pestanyasAmarillo = menuAmarillo.Q("Pestanyas");

        pestanya_azulMorado = pestanyasMorado.Q("Azul");
        pestanya_verdeMorado = pestanyasMorado.Q("Verde");

        contenido_azulMorado = contenidoMorado.Q("Azul");
        contenido_verdeMorado = contenidoMorado.Q("Verde");

        pestanya_azulNaranja = pestanyasNaranja.Q("Azul");
        pestanya_verdeNaranja = pestanyasNaranja.Q("Verde");

        contenido_azulNaranja = contenidoNaranja.Q("Azul");
        contenido_verdeNaranja = contenidoNaranja.Q("Verde");

        pestanya_azulAmarillo = pestanyasAmarillo.Q("Azul");
        pestanya_verdeAmarillo = pestanyasAmarillo.Q("Verde");

        contenido_azulAmarillo = contenidoAmarillo.Q("Azul");
        contenido_verdeAmarillo = contenidoAmarillo.Q("Verde");

        pestanya_azulMorado.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            contenido_azulMorado.style.display = DisplayStyle.Flex;
        });

        pestanya_verdeMorado.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            contenido_verdeMorado.style.display = DisplayStyle.Flex;
        });

        pestanya_azulNaranja.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            contenido_azulNaranja.style.display = DisplayStyle.Flex;
        });

        pestanya_verdeNaranja.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            contenido_verdeNaranja.style.display = DisplayStyle.Flex;
        });

        pestanya_azulAmarillo.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            contenido_azulAmarillo.style.display = DisplayStyle.Flex;
        });

        pestanya_verdeAmarillo.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            contenido_verdeAmarillo.style.display = DisplayStyle.Flex;
        });

    }
}
