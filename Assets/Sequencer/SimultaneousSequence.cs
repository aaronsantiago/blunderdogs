using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimultaneousSequence : SequenceItem
{
    public bool RequireAll = false;

    protected override void OnActivate()
    {
        foreach (Transform child in transform)
        {
            List<SequenceItem> sequenceItems = new List<SequenceItem>(child.GetComponents<SequenceItem>());
            foreach (SequenceItem sequenceItem in sequenceItems)
            {
                sequenceItem.Activate();
            }
        }
    }

    public override bool IsResponseSatisfied()
    {
        if (IsActive)
        {
            bool satisfied = true;
            foreach (Transform child in transform)
            {
                List<SequenceItem> sequenceItems = new List<SequenceItem>(child.GetComponents<SequenceItem>());
                foreach (SequenceItem sequenceItem in sequenceItems)
                {
                    if (sequenceItem.IsResponseSatisfied())
                    {
                      if (!RequireAll) return true;
                    }
                    else
                    {
                      satisfied = false;
                      if (RequireAll) break;
                    }
                }
                if (RequireAll && !satisfied) break;
            }
            return satisfied;
        }
        return false;
    }
}
