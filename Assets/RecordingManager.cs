using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordingManager : MonoBehaviour
{
    public static Dictionary<string, Dictionary<string, List<TransformData>>> Recordings = new Dictionary<string, Dictionary<string, List<TransformData>>>();
    public static Dictionary<string, RecordObjectsEvent> isRecording = new Dictionary<string, RecordObjectsEvent>();
    public static Dictionary<string, bool> wasRecording = new Dictionary<string, bool>();

    public static Dictionary<string, AudioClip> AudioRecordings = new Dictionary<string, AudioClip>();

    public bool OverwriteRecordings = true;

    void FixedUpdate()
    {
        foreach (var RecordingName in isRecording.Keys)
        {
            if (!wasRecording.ContainsKey(RecordingName))
            {
                wasRecording[RecordingName] = false;
            }
            if (isRecording[RecordingName] != null)
            {
                if (!wasRecording[RecordingName])
                {
                    wasRecording[RecordingName] = true;
                    string targetDevice = "";
                    foreach (var device in Microphone.devices)
                    {
                        if (targetDevice == "") targetDevice = device;
                        Debug.Log("Name: " + device);
                    }

                    AudioRecordings[RecordingName] = Microphone.Start(targetDevice, true, 10, 44100);
                    if (OverwriteRecordings) Recordings[RecordingName] = new Dictionary<string, List<TransformData>>();
                }
                if (!Recordings.ContainsKey(RecordingName))
                {
                    Recordings[RecordingName] = new Dictionary<string, List<TransformData>>();
                }
                foreach (Transform transform in isRecording[RecordingName].TransformsToRecord)
                {
                    if (!Recordings[RecordingName].ContainsKey(transform.name))
                    {
                        Recordings[RecordingName][transform.name] = new List<TransformData>();
                    }
                    TransformData data = new TransformData();
                    data.position = transform.localPosition;
                    data.rotation = transform.localRotation;
                    Recordings[RecordingName][transform.name].Add(data);
                }
            }
            else
            {
                if (wasRecording[RecordingName])
                {
                    string targetDevice = "";
                    foreach (var device in Microphone.devices)
                    {
                        if (targetDevice == "") targetDevice = device;
                        Debug.Log("Name: " + device);
                    }

                    Microphone.End(targetDevice);
                }
                wasRecording[RecordingName] = false;
            }
        }
    }
}
