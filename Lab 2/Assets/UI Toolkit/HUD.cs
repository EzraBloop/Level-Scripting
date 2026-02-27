using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    UIDocument ui;
    VisualElement rootVE;
    Label health, treasure;

    public TopDownPlayerMovement player;
    public GameStateManager state;

    private void Awake()
    {
        ui = GetComponent<UIDocument>();
        rootVE = ui.rootVisualElement;

        health = rootVE.Q<Label>("Health");
        treasure = rootVE.Q<Label>("Treasure");
    }

    private void Update()
    {
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        health.text = "Health " + player.hp.ToString();
        //treasure.text = "Treasure " + state.TreasureCollected.ToString();
    }

    private void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
