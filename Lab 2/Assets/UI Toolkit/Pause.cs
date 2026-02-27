using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    UIDocument ui;
    VisualElement rootVE;
    Button save, resume;
    bool paused = false;

    public InputAction pause;

    public JSonSaving saveing;

    private void Awake()
    {
        ui = GetComponent<UIDocument>();
        rootVE = ui.rootVisualElement;

        save = rootVE.Q<Button>("Save");
        resume = rootVE.Q<Button>("Resume");

        rootVE.style.display = DisplayStyle.None;
    }
    private void Update()
    {
        if(pause.WasPressedThisFrame())
        {
            if(!paused)
            {
                paused = true;
                OnPause();
            }
            else
            {
                paused = false;
                Time.timeScale = 1.0f;
                rootVE.style.display = DisplayStyle.None;
            }
        }
    }

    private void OnEnable()
    {
        pause.Enable();

        save.RegisterCallback<ClickEvent>(OnSave);
        resume.RegisterCallback<ClickEvent>(OnResume);
    }

    private void OnDisable()
    {
        pause.Disable();

        save.UnregisterCallback<ClickEvent>(OnSave);
        resume.UnregisterCallback<ClickEvent>(OnResume);
    }

    public void OnPause()
    {
        Time.timeScale = 0f;
        rootVE.style.display = DisplayStyle.Flex;

    }

    public void OnSave(ClickEvent evt)
    {
        Time.timeScale = 1.0f;
        saveing.SaveData();
        SceneManager.LoadScene("MenuScene");
    }

    public void OnResume(ClickEvent evt)
    {
        paused = false;
        Time.timeScale = 1.0f;
        rootVE.style.display = DisplayStyle.None;
    }
}
