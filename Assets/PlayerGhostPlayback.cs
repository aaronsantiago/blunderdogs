using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGhostPlayback : MonoBehaviour
{
    public List<Transform> TransformsToPlayback;

    public string RecordingName;

    int currentFrame;
    void FixedUpdate() {
        
        if (RecordingName == null || RecordingName == "") return;
        if (!RecordingManager.Recordings.ContainsKey(RecordingName))
        {
            Debug.Log("Recording name not found " + RecordingName);
            return;
        }
        var recording = RecordingManager.Recordings[RecordingName];
        foreach (Transform t in TransformsToPlayback)
        {
            if (!recording.ContainsKey(t.name))
            {
                Debug.Log("Transform name not found " + t.name);
                return;
            }
            List<TransformData> frames = recording[t.name];
            if (currentFrame >= frames.Count)
            {
                currentFrame = 0;
            }
            t.localPosition = frames[currentFrame].position;
            t.localRotation = frames[currentFrame].rotation;
        }
        currentFrame++;
    }
}
