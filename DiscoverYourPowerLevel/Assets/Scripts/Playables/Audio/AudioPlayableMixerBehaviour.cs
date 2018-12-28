using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Animations;
using UnityEngine.Video;
using System.Collections.Generic;

public class AudioPlayableMixerBehaviour : PlayableBehaviour
{
    public PlayableDirector Director;

    public IEnumerable<TimelineClip> Clips;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (Clips == null)
            return;

        AudioSource trackBinding = playerData as AudioSource;

        if (trackBinding == null)
            return;

        int inputCount = playable.GetInputCount();

        int inputPort = 0;
        foreach (TimelineClip clip in Clips)
        {
            var inputPlayable = (ScriptPlayable<AudioPlayableBehaviour>)playable.GetInput(inputPort);
            var input = inputPlayable.GetBehaviour();

            if (input != null)
            {
                input.AudioPlayer = trackBinding;
                double preloadTime = Math.Max(0.0, input.preloadTime);
                if (Director.time >= clip.start + clip.duration || Director.time <= clip.start - preloadTime)
                    input.StopAudio();
                else if (Director.time > clip.start - preloadTime)
                    input.PrepareAudio();

                if (input.shouldPlay && !input.AudioPlayer.isPlaying) {
                    input.PlayAudio();
                }
            }

            ++inputPort;
        }
    }
}
