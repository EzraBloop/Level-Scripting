using System.Collections.Generic;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class PauseMenu : MonoBehaviour
{
    private UIDocument menu;
    private Button startButton, quitButton;
    private List<Button> menuButtons = new List<Button>();
    private VisualElement VE;
    private InputAction controls;
    private Label score, previousScore;

    public GhostDataController tempData;

    private void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        controls = new InputAction();
        controls.Enable();

        menu = GetComponent<UIDocument>();

        VE = menu.rootVisualElement as VisualElement;
        score = menu.rootVisualElement.Q<Label>("HighScore");
        previousScore = menu.rootVisualElement.Q<Label>("PreviousScore");

        startButton = menu.rootVisualElement.Q("RestartButton") as Button;
        quitButton = menu.rootVisualElement.Q("MenuButton") as Button;
        menuButtons = menu.rootVisualElement.Query<Button>().ToList();

        VE.style.display = DisplayStyle.None;
    }

    private void Update()
    {
        
    }

    private void OnEnable()
    {
        startButton.RegisterCallback<NavigationSubmitEvent>(onStartGame);
        quitButton.RegisterCallback<NavigationSubmitEvent>(onQuitGame);

        controls.Enable();
    }

    private void OnDisable()
    {
        startButton.UnregisterCallback<NavigationSubmitEvent>(onStartGame);
        quitButton.UnregisterCallback<NavigationSubmitEvent>(onQuitGame);

        controls.Disable();
    }
    public void PauseGame()
    {
        VE.style.display = DisplayStyle.Flex;
        score.text = "Score this lap " + tempData.tempGhostData.ghostDataFrames.Count;
        previousScore.text = "Best score " + tempData.score;
        Time.timeScale = 0;

        UnityEngine.Cursor.visible = true;
        UnityEngine.Cursor.lockState = CursorLockMode.None;
    }
    private void onStartGame(NavigationSubmitEvent evt)
    {
        Time.timeScale = 1;
        Debug.Log("restart");
        SceneManager.LoadScene("SceneOne");
    }

    private void onQuitGame(NavigationSubmitEvent evt)
    {
        Time.timeScale = 1;
        SceneManager.UnloadSceneAsync("SceneOne");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
