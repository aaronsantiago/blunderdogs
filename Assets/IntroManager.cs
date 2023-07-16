using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public GameObject Intro;
    public GameObject Share;
    // Start is called before the first frame update
    void Start()
    {
        if(GhostManager.prevRecordingName == "")
        {
            Intro.SetActive(true);
            Share.SetActive(false);
        }
        else
        {
            Intro.SetActive(false);
            Share.SetActive(true);
        }
    }

    public void SwitchToIntro()
    {
        Intro.SetActive(true);
        Share.SetActive(false);
    }
}
