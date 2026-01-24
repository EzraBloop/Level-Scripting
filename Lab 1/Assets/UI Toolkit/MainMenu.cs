using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class MainMenu : MonoBehaviour
{
    private UIDocument menu;
    private Button startButton, quitButton;
    private List<Button> menuButtons = new List<Button>();
    private VisualElement VE;
    private InputAction controls;

    private void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        controls = new InputAction();
        controls.Enable();

        menu = GetComponent<UIDocument>();

        VE = menu.rootVisualElement as VisualElement;

        startButton = menu.rootVisualElement.Q("PlayButton") as Button;
        quitButton = menu.rootVisualElement.Q("QuitButton") as Button;
        menuButtons = menu.rootVisualElement.Query<Button>().ToList();

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
    private void onStartGame(NavigationSubmitEvent evt)
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("SceneOne", LoadSceneMode.Single);
        Debug.Log("Start Game");
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.Cursor.visible = false;
    }

    private void onQuitGame(NavigationSubmitEvent evt)
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
