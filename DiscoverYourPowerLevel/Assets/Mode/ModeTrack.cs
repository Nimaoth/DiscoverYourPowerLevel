using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(1f, 0f, 0f)]
[TrackClipType(typeof(IdleModeClip))]
[TrackClipType(typeof(MashSingleModeClip))]
public class ModeTrack : TrackAsset
{
    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        return ScriptPlayable<ModeMixerBehaviour>.Create(graph, inputCount);
    }
}
