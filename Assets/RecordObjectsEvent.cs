// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public struct TransformData
// {
//     public Vector3 position;
//     public Quaternion rotation;
// }

// public class RecordObjectsEvent : SequenceItem
// {
//     public List<Transform> TransformsToRecord;
//     public string RecordingName;
//     public bool ShouldStart = true;

//     protected override void OnActivate()
//     {
//         if (ShouldStart)
//         {
//             RecordingManager.isRecording[RecordingName] = this;
//         }
//         else
//         {
//             RecordingManager.isRecording[RecordingName] = null;
//         }
//     }
// }
