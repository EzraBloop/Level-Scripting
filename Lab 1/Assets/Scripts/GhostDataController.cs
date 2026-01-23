using UnityEngine;

public class GhostDataController : MonoBehaviour
{
    public GhostData tempGhostData = new GhostData();
    GhostData ghostData = new GhostData();
    private bool recording;
    public JSonSaving saving;
    int score;


    private void Start()
    {
        StartRecording();
        score = 99999999;
    }
    public void StartRecording()
    {
        recording = true;
    }

    public void FixedUpdate()
    {
        if (!recording) return;

        tempGhostData.AddFrame(transform.position, transform.eulerAngles);
    }

    public void SaveData()
    {
        if(tempGhostData.ghostDataFrames.Count < score && tempGhostData.ghostDataFrames.Count != 0)
        {
            ghostData = tempGhostData;
            score = ghostData.ghostDataFrames.Count;
            saving.SaveData("Mike", score, ghostData);
        }
        tempGhostData.ResetFrame();
    }
}