using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UEEvent : SequenceItem
{
    public UnityEvent unityEvent;
    protected override void OnActivate()
    {
        unityEvent.Invoke();
    }
}
