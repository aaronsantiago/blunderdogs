using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchSceneOnTouch : MonoBehaviour
{
    public string TargetScene;
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(TargetScene);
    }
}
