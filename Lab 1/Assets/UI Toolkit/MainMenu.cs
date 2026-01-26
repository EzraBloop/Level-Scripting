using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class MainMenu : MonoBehaviour
{
    private UIDocument menu;
    private Button startButton, quitButton, deleteButton, confirmDelete;
    private List<Button> menuButtons = new List<Button>();
    private VisualElement VE, profileVE;
    private InputAction controls;
    private TextField profileName;
    private Label title;

    public JSonSaving loading;
    SaveData saveData;

    private void Awake()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.None;
        UnityEngine.Cursor.visible = true;

        controls = new InputAction();
        controls.Enable();

        menu = GetComponent<UIDocument>();

        VE = menu.rootVisualElement as VisualElement;
        profileName = menu.rootVisualElement.Q<TextField>("ProfileName");
        title = menu.rootVisualElement.Q<Label>("Title");


        startButton = menu.rootVisualElement.Q("PlayButton") as Button;
        deleteButton = menu.rootVisualElement.Q("DeleteButton") as Button;
        confirmDelete = menu.rootVisualElement.Q("ConfirmDelete") as Button;
        quitButton = menu.rootVisualElement.Q("QuitButton") as Button;
        menuButtons = menu.rootVisualElement.Query<Button>().ToList();

        confirmDelete.SetEnabled(false);

    }

    private void OnEnable()
    {
        startButton.RegisterCallback<NavigationSubmitEvent>(onStartGame);
        //deleteButton.RegisterCallback<NavigationSubmitEvent>(onDeleteProfile);
        //confirmDelete.RegisterCallback<NavigationSubmitEvent>(onDeleteConfirmation);
        quitButton.RegisterCallback<NavigationSubmitEvent>(onQuitGame);

        controls.Enable();
    }

    private void OnDisable()
    {
        startButton.UnregisterCallback<NavigationSubmitEvent>(onStartGame);
        //deleteButton.UnregisterCallback<NavigationSubmitEvent>(onDeleteProfile);
        //confirmDelete.UnregisterCallback<NavigationSubmitEvent>(onDeleteConfirmation);
        quitButton.UnregisterCallback<NavigationSubmitEvent>(onQuitGame);

        controls.Disable();
    }
    private void onStartGame(NavigationSubmitEvent evt)
    {
        if (profileName.value.Length > 0)
        {
            GameManager.SetName(profileName.value);
            SceneManager.UnloadSceneAsync("Menu");
            SceneManager.LoadScene("SceneOne", LoadSceneMode.Single);
            Debug.Log("Start Game");
            UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            UnityEngine.Cursor.visible = false;    
        }
        else
        {
            title.text = "Please enter a profile name to continue";
        }
    }

    //private void onDeleteProfile(NavigationSubmitEvent evt)
    //{
    //    if(profileName.value.Length > 0)
    //    {
    //        GameManager.SetName(profileName.value);
    //        loading.UpdateProfileName(profileName.value);
    //       // LoadData();
    //        confirmDelete.SetEnabled(true);
    //        title.text = $"Are you sure you wish to delete {profileName.value}'s profile?";
            
    //    }
    //    else
    //    {
    //        title.text = "Please enter a profile name to delete";
    //    }
    //}

    //private void onDeleteConfirmation(NavigationSubmitEvent evt)
    //{
    //    loading.DeleteData();
    //}

    private void onQuitGame(NavigationSubmitEvent evt)
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

}
