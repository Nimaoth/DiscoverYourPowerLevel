using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Animations;
using UnityEngine.Video;
using System.Collections.Generic;

public class VideoPlayableMixerBehaviour : PlayableBehaviour
{
    public PlayableDirector Director;

    public IEnumerable<TimelineClip> Clips;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (Clips == null)
            return;

        VideoTarget trackBinding = playerData as VideoTarget;

        if (trackBinding == null)
            return;

        int inputCount = playable.GetInputCount();

        int inputPort = 0;
        foreach (TimelineClip clip in Clips)
        {
            var inputPlayable = (ScriptPlayable<VideoPlayableBehaviour>)playable.GetInput(inputPort);
            var input = inputPlayable.GetBehaviour();

            if (input != null)
            {
                input.VideoPlayer = trackBinding.Player;
                input.TargetTexture = trackBinding.Target;
                double preloadTime = Math.Max(0.0, input.preloadTime);
                if (Director.time >= clip.start + clip.duration ||
                    Director.time <= clip.start - preloadTime)
                    input.StopVideo();
                else if (Director.time > clip.start - preloadTime)
                    input.PrepareVideo();

                if (input.shouldPlay && !input.VideoPlayer.isPlaying) {
                    input.PlayVideo();
                }
            }

            ++inputPort;
        }
    }
}
