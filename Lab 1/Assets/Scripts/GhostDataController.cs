using UnityEngine;

public class GhostDataController : MonoBehaviour
{
    public GhostData tempGhostData = new GhostData();
    SaveData ghostData;
    private bool recording;
    public JSonSaving saving;
    public int score;

    private void Awake()
    {
        //ghostData = saving.LoadData();
    }
    private void Start()
    {
        //tempGhostData.ResetFrame();
        StartRecording();
        ghostData = saving.LoadData();
        if(ghostData.highScore != 0 && ghostData != null)
        {
            score = ghostData.highScore;
        }
        else
        {
            score = 0;
        }
        
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
        if(tempGhostData.ghostDataFrames.Count < score || score == 0)
        {
            //Debug.Log($"Slower Time {score}");
            
            score = tempGhostData.ghostDataFrames.Count;
            saving.SaveData(GameManager.GetName(), score, tempGhostData);
            //Debug.Log(GameManager.GetName());
            //Debug.Log($"Faster Time {score}");

        }
        else
        {
            Debug.Log($"Slower Time, score not saved");
        }
    }
}