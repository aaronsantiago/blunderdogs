using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaybackRecordingEvent : SequenceItem
{
    public List<Transform> TransformsToPlayback;
    public string RecordingName;
    protected bool isPlaying = false;
    protected bool isFinished = false;
    protected int currentFrame = 0;

    protected override void OnActivate()
    {
        isPlaying = true;
        isFinished = false;
        currentFrame = 0;
    }

    public override bool IsResponseSatisfied()
    {
        return isFinished;
    }

    protected override void OnDeactivate()
    {
        isPlaying = false;
        isFinished = false;
    }

    void FixedUpdate()
    {
        if (!isPlaying) return;
        if (!RecordingManager.Recordings.ContainsKey(RecordingName))
        {
            Debug.Log("Recording name not found " + RecordingName);
            isFinished = true;
            return;
        }
        var recording = RecordingManager.Recordings[RecordingName];
        foreach (Transform t in TransformsToPlayback)
        {
            if (!recording.ContainsKey(t.name))
            {
                Debug.Log("Transform name not found " + t.name);
                isFinished = true;
                return;
            }
            List<TransformData> frames = recording[t.name];
            if (currentFrame >= frames.Count)
            {
                isFinished = true;
                return;
            }
            t.localPosition = frames[currentFrame].position;
            t.localRotation = frames[currentFrame].rotation;
        }
        currentFrame++;
    }
}
