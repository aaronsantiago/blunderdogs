using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObstacleCourse : MonoBehaviour
{
    public GameObject Environment;
    public GameObject Intro;

    public static string RecordingName = "ObstacleCourse";

    public List<Transform> TransformsToRecord;
    private void OnTriggerEnter(Collider other)
    {
        Environment.SetActive(true);
        Intro.SetActive(false);

        RecordingName = System.Guid.NewGuid().ToString();

        RecordingManager.isRecording[RecordingName] = TransformsToRecord;
    }
}
