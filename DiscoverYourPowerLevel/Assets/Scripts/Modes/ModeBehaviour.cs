using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class ModeBehaviour : PlayableBehaviour
{
    protected Player player1;
    protected Player player2;

    protected AudioSource AudioSource;

    public GameObject UIPrefab;

    protected GameObject UI;

    private List<Coroutine> _coroutines = new List<Coroutine>();

    public void OnStart(Playable playable, FrameData info, Player player1, Player player2, AudioSource audioSource) {
        this.player1 = player1;
        this.player2 = player2;
        this.AudioSource = audioSource;

        if (Application.isPlaying) {
            UI = UIManager.Instance.SetModeUI(UIPrefab);
            OnStart();
        }
    }

    public void OnStop(Playable playable, FrameData info) {
        if (Application.isPlaying) {
            OnStop();
            UIManager.Instance.SetModeUI(null);
        }
    }

    public void OnUpdate(Playable playable, FrameData info) {
        if (Application.isPlaying) {
            OnUpdate(info.deltaTime);
        }
    }

    public Coroutine StartCoroutine(IEnumerator i) {
        var c = GameManager.Instance.StartCoroutineEnum(i);
        _coroutines.Add(c);
        return c;
    }

    public void StopCoroutine(Coroutine c) {
        GameManager.Instance.StopCoroutine(c);
        _coroutines.Remove(c);
    }

    public void StopAllCoroutines() {
        foreach (var c in _coroutines) {
            GameManager.Instance.StopCoroutine(c);
        }
        _coroutines.Clear();
    }

    public virtual void OnStart() {}

    public virtual void OnStop() {}

    public virtual void OnUpdate(float time) {}
}
