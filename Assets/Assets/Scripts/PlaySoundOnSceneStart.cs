using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnSceneStart : MonoBehaviour
{
    static bool firstLoadComplete = false;
    AudioSource audioSource;

    static string PrevSceneName = "";

    // Start is called before the first frame update
    void Start()
    {
        if(PrevSceneName != UnityEngine.SceneManagement.SceneManager.GetActiveScene().name)
        {
            PrevSceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
            firstLoadComplete = false;
        }
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
