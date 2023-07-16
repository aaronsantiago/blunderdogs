using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TransformData
{
    public Vector3 position;
    public Quaternion rotation;
}

public class RecordingManager : MonoBehaviour
{
    public static Dictionary<string, Dictionary<string, List<TransformData>>> Recordings = new Dictionary<string, Dictionary<string, List<TransformData>>>();

    public static int MaxRecordingFrames = 90;
    public static List<string> RecordingNames = new List<string>();
    public static int MaxRecords = 2;
    public static Dictionary<string, List<Transform>> isRecording = new Dictionary<string, List<Transform>>();
    public static Dictionary<string, bool> wasRecording = new Dictionary<string, bool>();

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

                    if (OverwriteRecordings) Recordings[RecordingName] = new Dictionary<string, List<TransformData>>();
                
                    if (isRecording.Keys.Count > MaxRecords)
                    {
                        string oldestRecording = RecordingNames[0];
                        RecordingNames.RemoveAt(0);
                        Recordings.Remove(oldestRecording);
                        isRecording.Remove(oldestRecording);
                        wasRecording.Remove(oldestRecording);
                    }
                    RecordingNames.Add(RecordingName);
                }
                if (!Recordings.ContainsKey(RecordingName))
                {
                    Recordings[RecordingName] = new Dictionary<string, List<TransformData>>();
                }
                foreach (Transform transform in isRecording[RecordingName])
                {
                    if (!Recordings[RecordingName].ContainsKey(transform.name))
                    {
                        Recordings[RecordingName][transform.name] = new List<TransformData>();
                    }
                    TransformData data = new TransformData();
                    data.position = transform.localPosition;
                    data.rotation = transform.localRotation;
                    Recordings[RecordingName][transform.name].Add(data);
                    if (Recordings[RecordingName][transform.name].Count > MaxRecordingFrames)
                    {
                        Recordings[RecordingName][transform.name].RemoveAt(0);
                    }
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
