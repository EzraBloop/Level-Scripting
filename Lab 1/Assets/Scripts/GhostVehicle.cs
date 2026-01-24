using UnityEngine;

public class GhostVehicle : MonoBehaviour
{
    public JSonSaving loading;
    SaveData saveData;
    int index;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Awake()
    {
        //LoadData();
    }
    void Start()
    {
        LoadData();
    }

    void FixedUpdate()
    {
         StartGhost();
    }

    public void StartGhost()
    {
        if (saveData != null)
        {
            if (index < saveData.ghostData.ghostDataFrames.Count)
            {
                transform.position = saveData.ghostData.ghostDataFrames[index].position;
                transform.rotation = Quaternion.Euler(saveData.ghostData.ghostDataFrames[index].rotation);
                index++;
            }
        }
    }

    public void LoadData()
    {
        saveData = loading.LoadData();
    }
}
