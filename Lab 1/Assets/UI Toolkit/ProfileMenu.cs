using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ProfileMenu : MonoBehaviour
{
    private UIDocument menu;
    private Button profileOneButton, profileTwoButton, deleteButton, backButton;
    private List<Button> menuButtons = new List<Button>();
    private VisualElement VE, profileVE;
    private InputAction controls;
    private Label profileOneName, profileTwoName, title;

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
        title = menu.rootVisualElement.Q<Label>("Title");
        profileOneName = menu.rootVisualElement.Q<Label>("ProfileOneName");
        profileTwoName = menu.rootVisualElement.Q<Label>("ProfileTwoName");


        profileOneButton = menu.rootVisualElement.Q("ProfileOneButton") as Button;
        profileTwoButton = menu.rootVisualElement.Q("ProfileTwoButton") as Button;
        deleteButton = menu.rootVisualElement.Q("DeleteProfileButton") as Button;
        backButton = menu.rootVisualElement.Q("BackButton") as Button;
        menuButtons = menu.rootVisualElement.Query<Button>().ToList();

        LoadData();

    }

    public void LoadData()
    {
        if(Application.persistentDataPath != null)
        {
            saveData = loading.LoadData();
        }
    }

    private void OnEnable()
    {
        profileOneButton.RegisterCallback<NavigationSubmitEvent>(onProfileOne);
        //profileTwoButton.RegisterCallback<NavigationSubmitEvent>();

        controls.Enable();
    }

    private void OnDisable()
    {
        profileOneButton.UnregisterCallback<NavigationSubmitEvent>(onProfileOne);
        //profileTwoButton.UnregisterCallback<NavigationSubmitEvent>();

        controls.Disable();
    }
    private void onProfileOne(NavigationSubmitEvent evt)
    {
        if (profileOneName.text == "Profile One")
        {

            //GameManager.SetName(profileOneName.text);
            //SceneManager.UnloadSceneAsync("Menu");
            //SceneManager.LoadScene("SceneOne", LoadSceneMode.Single);
            //Debug.Log("Start Game");
            //UnityEngine.Cursor.lockState = CursorLockMode.Locked;
            //UnityEngine.Cursor.visible = false;    
        }
        else
        {
            title.text = "Please enter a profile name to continue";
        }
    }

    private void onBack(NavigationSubmitEvent evt)
    {
        SceneManager.UnloadSceneAsync("ProfileMenu");
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}
