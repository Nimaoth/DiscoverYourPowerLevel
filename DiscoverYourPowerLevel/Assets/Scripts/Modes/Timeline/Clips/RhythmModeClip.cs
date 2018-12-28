using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class RhythmModeClip : PlayableAsset, ITimelineClipAsset
{
    public RhythmModeBehaviour template = new RhythmModeBehaviour();

    public ClipCaps clipCaps => ClipCaps.None;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<RhythmModeBehaviour>.Create(graph, template);
        return playable;
    }
}
