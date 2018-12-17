using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[TrackColor(1f, 0f, 0f)]
[TrackClipType(typeof(IdleModeClip))]
[TrackClipType(typeof(MashSingleModeClip))]
[TrackClipType(typeof(Alternating2ModeClip))]
[TrackClipType(typeof(Alternating3ModeClip))]
[TrackClipType(typeof(RhythmModeClip))]
public class ModeTrack : TrackAsset
{
    public Player Player1;
    public Player Player2;
    public ExposedReference<AudioSource> AudioSource;

    public override Playable CreateTrackMixer(PlayableGraph graph, GameObject go, int inputCount)
    {
        var mixer = ScriptPlayable<ModeMixerBehaviour>.Create(graph, inputCount);
        var mixerBehaviour = mixer.GetBehaviour();
        mixerBehaviour.Player1 = Player1;
        mixerBehaviour.Player2 = Player2;
        mixerBehaviour.AudioSource = AudioSource.Resolve(graph.GetResolver());
        return mixer;
    }
}
