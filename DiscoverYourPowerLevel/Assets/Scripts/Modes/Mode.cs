using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Mode : ScriptableObject {

    protected Player player1;
    protected Player player2;

    public AudioSource AudioSource;

    public GameObject UIPrefab;

    public GameObject UI;

    private List<Coroutine> _coroutines = new List<Coroutine>();

    public virtual void Start() {
        player1 = GameManager.Instance.Player1;
        player2 = GameManager.Instance.Player2;
        AudioSource = ClipManager.Instance.ClipAudioSource;

        UI = UIManager.Instance.SetModeUI(UIPrefab);
    }

    public virtual void Stop() {
        if (UI != null) {
            Destroy(UI);
        }

        StopAllCoroutines();
    }

    public abstract void OnUpdate(float time);

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
}
