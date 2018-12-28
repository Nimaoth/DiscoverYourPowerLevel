using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Animations;
using UnityEngine.Video;
using System;

[TrackColor(0f, 0f, 1f)]
[TrackClipType(typeof(AudioPlayableClip))]
[TrackBindingType(typeof(AudioSource))]
public class AudioPlayableTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var playableDirector = go.GetComponent<PlayableDirector>();
        var playable = ScriptPlayable<AudioPlayableMixerBehaviour>.Create(graph, inputCount);
        var behaviour = playable.GetBehaviour();

        if (behaviour != null)
        {
            behaviour.Director = playableDirector;
            behaviour.Clips = GetClips();
        }

        return playable;
    }
}
