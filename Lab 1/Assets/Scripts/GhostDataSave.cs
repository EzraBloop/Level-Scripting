using System.IO;
using UnityEngine;

public class GhostDataSave : MonoBehaviour
{
    public string ghostfilePath;
    public GhostData ghostData;

    public void CreateGhostSave()
    {
        bool fileExists = File.Exists(ghostfilePath);

        using (StreamWriter writer = new StreamWriter(ghostfilePath, true))
        {
            if (!fileExists)
            {
                writer.WriteLine("PosX, PosY, PosZ, RotX, RotY, RotZ");
            }

            for(int i = 0; i < ghostData.ghostDataFrames.Count; i++)
            {
                writer.WriteLine($"{ghostData.ghostDataFrames[i].position.x}, {ghostData.ghostDataFrames[i].position.y}, {ghostData.ghostDataFrames[i].position.z}, {ghostData.ghostDataFrames[i].rotation.x}, {ghostData.ghostDataFrames[i].rotation.y}, {ghostData.ghostDataFrames[i].rotation.z}");

            }
            
        }
    }
}
