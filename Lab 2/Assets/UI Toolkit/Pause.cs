using UnityEngine;
using UnityEngine.UIElements;

public class Pause : MonoBehaviour
{
    UIDocument ui;
    VisualElement rootVE;
    Button save;

    public JSonSaving saveing;

    private void Awake()
    {
        ui = GetComponent<UIDocument>();
        rootVE = ui.rootVisualElement;
        save = rootVE.Q<Button>("Save");
    }

    private void OnEnable()
    {
        save.RegisterCallback<ClickEvent>(OnSave);
    }

    private void OnDisable()
    {
        save.UnregisterCallback<ClickEvent>(OnSave);
    }

    public void OnSave(ClickEvent evt)
    {
        saveing.SaveData();
    }
}
