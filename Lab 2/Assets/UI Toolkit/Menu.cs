using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Menu : MonoBehaviour
{
    UIDocument ui;
    VisualElement rootVE;
    Button newGame, resume, quit;

    public JSonSaving saveing;

    private void Awake()
    {
        ui = GetComponent<UIDocument>();
        rootVE = ui.rootVisualElement;
        newGame = rootVE.Q<Button>("NewGame");
        resume = rootVE.Q<Button>("Continue");
        quit = rootVE.Q<Button>("Quit");

        if(!File.Exists(saveing.filePath))
        {
            resume.SetEnabled(false);
        }
        else
        {
            resume.SetEnabled(true);
        }
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
        SceneManager.LoadScene("SceneOne");
    }

    public void OnContinue(ClickEvent evt)
    {
        saveing.LoadData();
    }

    public void OnQuit(ClickEvent evt)
    {
        Application.Quit();
    }
}
