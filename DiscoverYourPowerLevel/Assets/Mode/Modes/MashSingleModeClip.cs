using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class MashSingleModeClip : PlayableAsset, ITimelineClipAsset
{
    public MashSingleModeBehaviour template = new MashSingleModeBehaviour();

    public ClipCaps clipCaps => ClipCaps.None;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<MashSingleModeBehaviour>.Create(graph, template);
        return playable;
    }
}
