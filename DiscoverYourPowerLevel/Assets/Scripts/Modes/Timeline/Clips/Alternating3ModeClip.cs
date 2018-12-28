using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class Alternating3ModeClip : PlayableAsset, ITimelineClipAsset
{
    public Alternating3ModeBehaviour template = new Alternating3ModeBehaviour();

    public ClipCaps clipCaps => ClipCaps.None;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<Alternating3ModeBehaviour>.Create(graph, template);
        return playable;
    }
}
