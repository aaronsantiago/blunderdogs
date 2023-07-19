using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObstacleCourse : MonoBehaviour
{
    public GameObject Environment;
    public GameObject Intro;

    private List<Collider> _colliders = new List<Collider>();

    private void OnTriggerEnter(Collider other)
    {
        _colliders.Add(other);
        if (_colliders.Count == 3)
        {
            startObstacleCourse();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _colliders.Remove(other);
    }

    void startObstacleCourse()
    {
        GhostManager.Instance.SpawnAllReplays();
        GhostManager.Instance.StartRecording();
        Environment.SetActive(true);
        Intro.SetActive(false);
    }
}
