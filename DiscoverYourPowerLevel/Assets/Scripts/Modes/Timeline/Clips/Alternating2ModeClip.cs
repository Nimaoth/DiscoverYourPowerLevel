using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class Alternating2ModeClip : PlayableAsset, ITimelineClipAsset
{
    public Alternating2ModeBehaviour template = new Alternating2ModeBehaviour();

    public ClipCaps clipCaps => ClipCaps.None;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<Alternating2ModeBehaviour>.Create(graph, template);
        return playable;
    }
}
