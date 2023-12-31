using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderedSequence : SequenceItem
{
    public bool Loop = false;

    public void SetLoop(bool loop)
    {
        Loop = loop;
    }
    protected virtual void Update()
    {
        if (IsActive)
        {
            bool activateNext = false;
            foreach (Transform child in transform)
            {
                bool foundUnsatisfied = false;
                List<SequenceItem> sequenceItems = new List<SequenceItem>(child.GetComponents<SequenceItem>());
                foreach (SequenceItem sequenceItem in sequenceItems)
                {
                    if (activateNext)
                    {
                        sequenceItem.Activate();
                    }
                    if (!sequenceItem.IsActive)
                    {
                        foundUnsatisfied = true;
                        continue;
                    }
                    if (!sequenceItem.IsResponseSatisfied())
                    {
                        foundUnsatisfied = true;
                    }

                }
                activateNext = false;

                if (!foundUnsatisfied)
                {
                    activateNext = true;
                    foreach (SequenceItem sequenceItem in sequenceItems) sequenceItem.Deactivate();
                }
            }
        }
    }

    protected override void OnActivate()
    {
        foreach (Transform child in transform)
        {
            List<SequenceItem> sequenceItems = new List<SequenceItem>(child.GetComponents<SequenceItem>());
            bool activated = false;
            foreach (SequenceItem sequenceItem in sequenceItems)
            {
                sequenceItem.Activate();
                activated = true;
            }
            if (activated) return;
        }
    }

    // protected override void OnDeactivate()
    // {
    //     if (Loop)
    //     {
    //         Activate();
    //     }
    // }

    public override bool IsResponseSatisfied()
    {
        if (IsActive)
        {
            foreach (Transform child in transform)
            {
                List<SequenceItem> sequenceItems = new List<SequenceItem>(child.GetComponents<SequenceItem>());
                foreach (SequenceItem sequenceItem in sequenceItems)
                {
                    if (sequenceItem.IsActive) return false;
                }
            }
            if (Loop) {
                Activate();
                return false;
            }
            return true;
        }
        return false;
    }
}
