using UnityEngine;

public class GhostDataController : MonoBehaviour
{
    public GhostData ghostData = new GhostData();
    private bool recording;


    private void Start()
    {
        StartRecording();
    }
    public void StartRecording()
    {
        recording = true;
    }

    public void FixedUpdate()
    {
        if (!recording) return;

        ghostData.AddFrame(transform.position, transform.eulerAngles);
    }
}