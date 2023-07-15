using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableEvent : SequenceItem
{
    public GameObject ToEnable;

    public bool SettingEnable = true;
    protected override void OnActivate()
    {
        ToEnable.SetActive(SettingEnable);
    }

    public override bool IsResponseSatisfied()
    {
        return true;
    }
}
