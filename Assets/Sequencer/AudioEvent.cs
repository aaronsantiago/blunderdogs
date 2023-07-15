using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEvent : SequenceItem
{
    public bool WaitForAudioCompletion = false;
    public bool AudioCompletionUsePercentage = false;
    public float AudioCompletionOffset = 0;
    public bool PlayOnActivate = true;

    public AudioSource audioSource;
    protected override void OnActivate()
    {
        if (audioSource != null) {
            if (PlayOnActivate) audioSource.Play();
        }
    }

    public override bool IsResponseSatisfied()
    {
        if (!WaitForAudioCompletion) return true;

        if (audioSource == null) return true;
        float audioCompletionOffsetSeconds = AudioCompletionOffset;
        if (AudioCompletionUsePercentage) {
            audioCompletionOffsetSeconds = audioSource.clip.length * AudioCompletionOffset;
        }

        if (!audioSource.isPlaying || audioSource.time + audioCompletionOffsetSeconds > audioSource.clip.length
            || Mathf.Approximately(audioSource.time + audioCompletionOffsetSeconds, audioSource.clip.length)) {
            return true;
        }


        return false;
    }
}
