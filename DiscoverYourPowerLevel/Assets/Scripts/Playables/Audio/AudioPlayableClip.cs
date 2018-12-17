using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Animations;
using UnityEngine.Video;

[Serializable]
public class AudioPlayableClip : PlayableAsset, ITimelineClipAsset
{
    [SerializeField, NotKeyable]
    public AudioClip AudioClip;

    public ClipCaps clipCaps => ClipCaps.None;

    public override double duration {
        get {
            if (AudioClip == null) {
                return base.duration;
            }

            return (double)AudioClip.samples / (double)AudioClip.frequency;
        }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<AudioPlayableBehaviour>.Create(graph);
        playable.SetDuration(AudioClip.length);
        AudioPlayableBehaviour behaviour = playable.GetBehaviour();
        behaviour.AudioClip = AudioClip;
        return playable;
    }
}
