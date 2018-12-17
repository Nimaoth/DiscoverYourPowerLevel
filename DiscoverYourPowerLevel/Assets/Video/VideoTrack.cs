using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Animations;
using UnityEngine.Video;
using System;

[TrackColor(0f, 1f, 0f)]
[TrackClipType(typeof(VideoPlayableClip))]
[TrackBindingType(typeof(VideoTarget))]
public class VideoTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var playableDirector = go.GetComponent<PlayableDirector>();
        var playable = ScriptPlayable<VideoPlayableMixerBehaviour>.Create(graph, inputCount);
        var behaviour = playable.GetBehaviour();

        if (behaviour != null)
        {
            behaviour.Director = playableDirector;
            behaviour.Clips = GetClips();
        }

        return playable;
    }
}
