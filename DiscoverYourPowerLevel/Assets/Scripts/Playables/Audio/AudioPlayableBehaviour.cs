using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.UI;

[Serializable]
public class AudioPlayableBehaviour : PlayableBehaviour
{
    public AudioSource AudioPlayer;

    public AudioClip AudioClip;

    private bool playedOnce = false;
    public bool shouldPlay = false;
    public double preloadTime = 0.3;

    public void PrepareAudio()
    {
        if (AudioPlayer == null || AudioClip == null)
            return;

        if (AudioPlayer.clip != AudioClip)
            StopAudio();

        AudioPlayer.clip = AudioClip;
        AudioPlayer.playOnAwake = false;
    }

    public override void PrepareFrame(Playable playable, FrameData info)
    {
        SyncAudioToPlayable(playable);
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (!playedOnce)
        {
            PlayAudio();
            SyncAudioToPlayable(playable);
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (Application.isPlaying)
            PauseAudio();
        else
            StopAudio();
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        Debug.Log(AudioPlayer.isPlaying);
        if (AudioPlayer == null || AudioPlayer.clip == null)
            return;
    }

    public override void OnGraphStart(Playable playable)
    {
        playedOnce = false;
    }

    public override void OnGraphStop(Playable playable)
    {
        if (!Application.isPlaying)
            StopAudio();
    }

    public override void OnPlayableDestroy(Playable playable)
    {
        StopAudio();
    }

    public void PlayAudio()
    {
        shouldPlay = true;
        if (AudioPlayer == null)
            return;

        AudioPlayer.Play();

        if (!Application.isPlaying)
            PauseAudio();
    }

    public void PauseAudio()
    {
        if (AudioPlayer == null)
            return;

        AudioPlayer.Pause();
        shouldPlay = false;
    }

    public void StopAudio()
    {
        if (AudioPlayer == null)
            return;

        playedOnce = false;
        AudioPlayer.Stop();
        shouldPlay = false;
    }

    private void SyncAudioToPlayable(Playable playable)
    {
        if (AudioPlayer == null || AudioPlayer.clip == null)
            return;

        AudioPlayer.time = (float)(playable.GetTime() % AudioPlayer.clip.length);
    }
}
