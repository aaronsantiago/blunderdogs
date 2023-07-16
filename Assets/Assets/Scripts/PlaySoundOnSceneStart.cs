using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnSceneStart : MonoBehaviour
{
    static bool firstLoadComplete = false;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        if (!firstLoadComplete)
        {
            firstLoadComplete = true;
            return;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
