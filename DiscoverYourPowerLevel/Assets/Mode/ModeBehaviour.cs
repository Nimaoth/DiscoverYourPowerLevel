using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[Serializable]
public class ModeBehaviour : PlayableBehaviour
{
    public Player player1;
    public Player player2;

    private List<Coroutine> _coroutines = new List<Coroutine>();

    public void OnStart(Playable playable, FrameData info) {
        OnStart();
    }

    public void OnStop(Playable playable, FrameData info) {
        OnStop();
    }

    public void OnUpdate(Playable playable, FrameData info) {
        OnUpdate(info.deltaTime);
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
