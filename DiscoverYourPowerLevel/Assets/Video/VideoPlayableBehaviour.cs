using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Animations;
using UnityEngine.Video;
using UnityEngine.UI;

[Serializable]
public class VideoPlayableBehaviour : PlayableBehaviour
{
    public VideoPlayer VideoPlayer;
    public RawImage TargetTexture;

    public VideoClip VideoClip;
    public bool mute = false;
    public bool loop = true;
    public double preloadTime = 0.3;
    public double clipInTime = 0.0;


    private bool playedOnce = false;
    private bool preparing = false;

    private RenderTexture renderTexture;

    public void PrepareVideo()
    {
        if (VideoPlayer == null || VideoClip == null)
            return;

        if (renderTexture == null)
        {
            renderTexture = new RenderTexture((int)VideoClip.width, (int)VideoClip.height, 0, RenderTextureFormat.ARGB32);
            VideoPlayer.targetTexture = renderTexture;
            TargetTexture.texture = renderTexture;
        }

        VideoPlayer.targetCameraAlpha = 0.0f;

        if (VideoPlayer.clip != VideoClip)
            StopVideo();

        if (VideoPlayer.isPrepared || preparing)
            return;

        VideoPlayer.source = VideoSource.VideoClip;
        VideoPlayer.clip = VideoClip;
        VideoPlayer.playOnAwake = false;
        VideoPlayer.waitForFirstFrame = true;
        VideoPlayer.isLooping = loop;

        for (ushort i = 0; i < VideoClip.audioTrackCount; ++i)
        {
            if (VideoPlayer.audioOutputMode == VideoAudioOutputMode.Direct)
                VideoPlayer.SetDirectAudioMute(i, mute || !Application.isPlaying);
            else if (VideoPlayer.audioOutputMode == VideoAudioOutputMode.AudioSource)
            {
                AudioSource audioSource = VideoPlayer.GetTargetAudioSource(i);
                if (audioSource != null)
                    audioSource.mute = mute || !Application.isPlaying;
            }
        }

        VideoPlayer.loopPointReached += LoopPointReached;
        VideoPlayer.time = clipInTime;
        VideoPlayer.Prepare();
        preparing = true;
    }

    void LoopPointReached(VideoPlayer vp)
    {
        playedOnce = !loop;
    }

    public override void PrepareFrame(Playable playable, FrameData info)
    {
        if (VideoPlayer == null || VideoClip == null)
            return;

        VideoPlayer.timeReference = Application.isPlaying ? VideoTimeReference.ExternalTime :
                                                            VideoTimeReference.Freerun;

        if (VideoPlayer.isPlaying && Application.isPlaying)
            VideoPlayer.externalReferenceTime = playable.GetTime();
        else if (!Application.isPlaying)
            SyncVideoToPlayable(playable);
    }

    public override void OnBehaviourPlay(Playable playable, FrameData info)
    {
        if (!playedOnce)
        {
            PlayVideo();
            SyncVideoToPlayable(playable);
        }
    }

    public override void OnBehaviourPause(Playable playable, FrameData info)
    {
        if (Application.isPlaying)
            PauseVideo();
        else
            StopVideo();
    }

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (VideoPlayer == null || VideoPlayer.clip == null)
            return;

        VideoPlayer.targetCameraAlpha = info.weight;

        if (Application.isPlaying)
        {
            for (ushort i = 0; i < VideoPlayer.clip.audioTrackCount; ++i)
            {
                if (VideoPlayer.audioOutputMode == VideoAudioOutputMode.Direct)
                    VideoPlayer.SetDirectAudioVolume(i, info.weight);
                else if (VideoPlayer.audioOutputMode == VideoAudioOutputMode.AudioSource)
                {
                    AudioSource audioSource = VideoPlayer.GetTargetAudioSource(i);
                    if (audioSource != null)
                        audioSource.volume = info.weight;
                }
            }
        }
    }

    public override void OnGraphStart(Playable playable)
    {
        playedOnce = false;
    }

    public override void OnGraphStop(Playable playable)
    {
        if (!Application.isPlaying)
            StopVideo();
    }

    public override void OnPlayableDestroy(Playable playable)
    {
        StopVideo();
    }

    public bool shouldPlay = false;
    public void PlayVideo()
    {
        shouldPlay = true;
        if (VideoPlayer == null)
            return;

        VideoPlayer.Play();
        preparing = false;

        if (!Application.isPlaying)
            PauseVideo();
    }

    public void PauseVideo()
    {
        shouldPlay = false;
        if (VideoPlayer == null)
            return;

        VideoPlayer.Pause();
        preparing = false;
    }

    public void StopVideo()
    {
        shouldPlay = false;
        if (VideoPlayer == null)
            return;

        playedOnce = false;
        VideoPlayer.Stop();
        preparing = false;
    }

    private void SyncVideoToPlayable(Playable playable)
    {
        if (VideoPlayer == null || VideoPlayer.clip == null)
            return;

        VideoPlayer.time = (clipInTime + (playable.GetTime() * VideoPlayer.playbackSpeed)) % VideoPlayer.clip.length;
    }
}
