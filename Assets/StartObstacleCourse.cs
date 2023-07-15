using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObstacleCourse : MonoBehaviour
{
    public GameObject Environment;
    public GameObject Intro;
    private void OnTriggerEnter(Collider other)
    {
        Environment.SetActive(true);
        Intro.SetActive(false);
    }
}
