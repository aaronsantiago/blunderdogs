using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyTransformEvent : SequenceItem
{
    public Transform Source;
    public Transform Destination;

    protected override void OnActivate()
    {
        Destination.position = Source.position;
        Destination.rotation = Source.rotation;
    }

    public override bool IsResponseSatisfied()
    {
        return true;
    }
}
