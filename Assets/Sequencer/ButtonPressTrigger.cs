using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonPressTrigger : SequenceItem
{

    public bool buttonPressed = false;

    protected override void OnActivate()
    {
        buttonPressed = false;
    }

    public void OnButtonPress(InputAction.CallbackContext context)
    {
        if (IsActive)
        {
            buttonPressed = true;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (IsActive)
            {
                buttonPressed = true;
            }
        }
    }

    public override bool IsResponseSatisfied()
    {
        return buttonPressed;
    }
}
