using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObstacleCourse : MonoBehaviour
{
    public GameObject Environment;
    private void OnTriggerEnter(Collider other)
    {
        Environment.SetActive(true);
    }
}
