using UnityEngine;
using UnityEngine.UIElements;

public class GameMenuPestanyas : MonoBehaviour
{
    VisualElement button_characters;
    VisualElement button_game;
    VisualElement pestanya_characters;
    VisualElement pestanya_game;

    Button ajustes;
    Button exitAjustes;
    VisualElement ajustesWindow;
    private void NoContenido()
    {
        pestanya_characters.style.display = DisplayStyle.None;
        pestanya_game.style.display = DisplayStyle.None;
        ajustesWindow.style.display = DisplayStyle.None;
    }

    private void OnEnable()
    {
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
        });

        button_game.RegisterCallback<MouseDownEvent>(evt =>
        {
            NoContenido();
            pestanya_game.style.display = DisplayStyle.Flex;
        });


    }
}
