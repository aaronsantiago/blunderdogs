using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostManager : MonoBehaviour
{
    public static GhostManager Instance;
    public List<Transform> TransformsToRecord;

    public GameObject PlayerGhostPrefab;

    public static string prevRecordingName = "";
    string RecordingName = "";

    static string PrevSceneName = "";
    GameObject prevRecord;

    void Update() {
    }

    void Start()
    {
        Instance = this;

        if(PrevSceneName != UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            PrevSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            prevRecordingName = "";
            RecordingManager.Recordings.Clear();
            RecordingManager.RecordingNames.Clear();
            RecordingManager.isRecording.Clear();
            RecordingManager.wasRecording.Clear();
        }
        if (prevRecordingName != "")
        {
            Debug.Log("Spawning recording name: " + prevRecordingName);
            prevRecord = Instantiate(PlayerGhostPrefab);

            prevRecord.GetComponent<PlayerGhostPlayback>().RecordingName = prevRecordingName;
        }
    }

    public void AcceptRecord() {
        Destroy(prevRecord);
    }

    public void RejectRecord() {

        RecordingManager.Recordings.Remove(prevRecordingName);
        RecordingManager.RecordingNames.Remove(prevRecordingName);
        RecordingManager.isRecording.Remove(prevRecordingName);
        RecordingManager.wasRecording.Remove(prevRecordingName);
        Destroy(prevRecord);
    }

    public void SpawnAllReplays() {

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
        prevRecordingName = RecordingName;
    }
    
    public void StopRecording()
    {
        RecordingManager.isRecording[RecordingName] = null;
        prevRecordingName = RecordingName;
    }
}
