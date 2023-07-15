using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateMaterialPropertyEvent : SequenceItem
{
    public float AnimationDuration = 1f;
    public float StartValue = 0f;
    public float TargetValue = 0f;

    public string PropertyName = "_DepthThreshold";

    public MeshRenderer renderer;

    float elapsedTime = 0f;

    protected override void OnActivate()
    {
        elapsedTime = 0f;
        renderer.material.SetFloat(PropertyName, StartValue);
    }

    public override bool IsResponseSatisfied()
    {
        return elapsedTime >= AnimationDuration;
    }
    
    void Update() {
        if (IsActive) {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / AnimationDuration;
            float value = Mathf.Lerp(StartValue, TargetValue, Mathf.Min(t, 1f));
            renderer.material.SetFloat(PropertyName, value);
        }
    }
}
