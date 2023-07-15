using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform ToFollow;
    public Vector3 Offset = new Vector3(0, 0, 0);

    // Update is called once per frame
    void Update()
    {
        if (ToFollow)
        {
            transform.position = ToFollow.position + Offset;
            transform.rotation = ToFollow.rotation;
        }
    }
}
