using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class IdleModeClip : PlayableAsset, ITimelineClipAsset
{
    public IdleModeBehaviour template = new IdleModeBehaviour();

    public ClipCaps clipCaps => ClipCaps.None;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<IdleModeBehaviour>.Create(graph, template);
        return playable;
    }
}
