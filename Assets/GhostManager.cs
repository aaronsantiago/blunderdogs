using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public static GhostManager Instance;
    public List<Transform> TransformsToRecord;

    public GameObject PlayerGhostPrefab;

    string RecordingName = "";

    void Start()
    {
        Instance = this;

        foreach (var RecordingName in RecordingManager.Recordings.Keys)
        {
            Debug.Log("Spawning recording name: " + RecordingName);
            GameObject ghost = Instantiate(PlayerGhostPrefab);

            ghost.GetComponent<PlayerGhostPlayback>().RecordingName = RecordingName;
        }
    }

    public void StartRecording()
    {
        RecordingName = System.Guid.NewGuid().ToString();
        RecordingManager.isRecording[RecordingName] = TransformsToRecord;
    }
    
    public void StopRecording()
    {
        RecordingManager.isRecording[RecordingName] = null;
    }
}
