using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTrigger : MonoBehaviour
{
    public Vector3 MoveVector = new Vector3(0, 0, 0);

    public float ResetTime = 0.0f;
    float resetTimer = 0.0f;

    Vector3 originalPosition;
    bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(isMoving) {
            transform.position += MoveVector * Time.deltaTime;
            resetTimer += Time.deltaTime;
            if(resetTimer >= ResetTime) {
                isMoving = false;
                resetTimer = 0.0f;
            }
        }
        else {
            transform.position = originalPosition;
        }
    }

    public void TriggerMove() {
        isMoving = true;
    }
}
