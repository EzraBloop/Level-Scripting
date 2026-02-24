using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    UIDocument ui;
    VisualElement rootVE;
    Button newGame, resume, quit;

    private void Awake()
    {
        ui = GetComponent<UIDocument>();
        rootVE = ui.rootVisualElement;
        newGame = rootVE.Q<Button>("NewGame");
        resume = rootVE.Q<Button>("Continue");
        quit = rootVE.Q<Button>("Quit");


    }

    private void OnEnable()
    {
        newGame.RegisterCallback<ClickEvent>(OnNewGame);
        resume.RegisterCallback<ClickEvent>(OnContinue);
        quit.RegisterCallback<ClickEvent>(OnQuit);
    }

    private void OnDisable()
    {
        newGame.UnregisterCallback<ClickEvent>(OnNewGame);
        resume.UnregisterCallback<ClickEvent>(OnContinue);
        quit.UnregisterCallback<ClickEvent>(OnQuit);
    }

    public void OnNewGame(ClickEvent evt)
    {

    }

    public void OnContinue(ClickEvent evt)
    {

    }

    public void OnQuit(ClickEvent evt)
    {
        Application.Quit();
    }
}
