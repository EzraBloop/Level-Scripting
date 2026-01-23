using UnityEngine;

public class GhostVehicle : MonoBehaviour
{
    public JSonSaving loading;
    SaveData saveData;
    int index;
    bool ghostPlayback;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadData();
    }

    void FixedUpdate()
    {
        if(ghostPlayback)
        {
            StartGhost();
        }
    }

    public void StartGhost()
    {
        if (index < saveData.ghostData.ghostDataFrames.Count)
        {
            transform.position = saveData.ghostData.ghostDataFrames[index].position;
            transform.rotation = Quaternion.Euler(saveData.ghostData.ghostDataFrames[index].rotation);
            index++;
        }

        if (index == saveData.ghostData.ghostDataFrames.Count)
        {
            ghostPlayback = false;
        }
    }

    public void LoadData()
    {
        saveData = loading.LoadData();
    }
}
