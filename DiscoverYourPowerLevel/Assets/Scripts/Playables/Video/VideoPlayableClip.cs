using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Animations;
using UnityEngine.Video;

[Serializable]
public class VideoPlayableClip : PlayableAsset, ITimelineClipAsset
{
    [SerializeField, NotKeyable]
    public VideoClip VideoClip;

    [SerializeField, NotKeyable]
    public bool mute = false;

    [SerializeField, NotKeyable]
    public bool loop = true;

    [SerializeField, NotKeyable]
    public double preloadTime = 0.3;

    [SerializeField, NotKeyable]
    public double clipInTime = 0.0;

    public ClipCaps clipCaps => ClipCaps.None;

    public override double duration {
        get {
            if (VideoClip == null) {
                return base.duration;
            }

            return VideoClip.length;
        }
    }

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<VideoPlayableBehaviour>.Create(graph);
        playable.SetDuration(VideoClip.length);
        VideoPlayableBehaviour behaviour = playable.GetBehaviour();
        behaviour.VideoClip = VideoClip;
        behaviour.mute = mute;
        behaviour.loop = loop;
        behaviour.preloadTime = preloadTime;
        behaviour.clipInTime = clipInTime;
        return playable;
    }
}
