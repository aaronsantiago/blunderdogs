using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resetter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn")) {
            GhostManager.Instance.StopRecording();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
