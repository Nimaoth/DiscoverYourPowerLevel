using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public enum ButtonInput
{
    RED,
    BLACK,
    WHITE,
    GREEN,
    YELLOW,
    BLUE
};

[CreateAssetMenu(menuName = "Custom/Modes/RhythmMode")]
public class RhythmMode : Mode {
    public ButtonInput Player1Key;
    public ButtonInput Player2Key;

    public bool RandomiseButtons = true;

    public int LossPerHit;
    public int GainPerHit;

    public float bpm;
    public float timingAccuracy;
    public float tickOffset;
    public float klickOffset;
    public float circleOffset;
    public float timer;

    public AudioClip testSound;

    public Effect tickEffect;

    private HitCircle hitCircle1;
    private HitCircle hitCircle2;

    private Image flash1;
    private Image flash2;

    public float flashSpeed = 5;
    public float circleSize = 5;

    float lastTimer = 0;

    private bool p1canHit = true;
    private bool p2canHit = true;

    public override void Start()
    {
        base.Start();
        timer = tickOffset;

        Player1Key = ButtonInput.RED;
        Player2Key = ButtonInput.BLUE;

        // if (RandomiseButtons) {
        //     List<ButtonInput> buttons = new List<ButtonInput>((ButtonInput[])Enum.GetValues(typeof(ButtonInput)));
        //     Player1Key = buttons[UnityEngine.Random.Range(0, buttons.Count)];
        //     Player2Key = buttons[UnityEngine.Random.Range(0, buttons.Count)];
        // }

        var p1 = UI.transform.Find("p1");
        var p2 = UI.transform.Find("p2");

        foreach (var c in p1.gameObject.GetChildren())
            c.SetActive(false);
        foreach (var c in p2.gameObject.GetChildren())
            c.SetActive(false);

        var b1 = p1.transform.Find(Player1Key.ToString());
        var b2 = p2.transform.Find(Player2Key.ToString());

        b1.gameObject.SetActive(true);
        b2.gameObject.SetActive(true);

        hitCircle1 = b1.GetComponent<HitCircle>();
        hitCircle2 = b2.GetComponent<HitCircle>();

        hitCircle1.MaxScale = circleSize;
        hitCircle2.MaxScale = circleSize;

        flash1 = b1.transform.Find("Flash").GetComponent<Image>();
        flash2 = b2.transform.Find("Flash").GetComponent<Image>();
    }

    public override void Stop() {
        base.Stop();
    }

    public override void OnUpdate(float time)
    {
        float progress = AudioSource.time;

        // time between beats
        float tbb = 60 / bpm;


        timer = (progress + tickOffset) % tbb;
        if (Mathf.Abs(timer - lastTimer) > 0.5f * tbb) {
            // EffectManager.Instance.PlayPosEffect();
            AudioSource.PlayClipAtPoint(testSound, Vector3.zero);

            if (tickEffect != null) {
                tickEffect.Spawn();
            }
        }
        lastTimer = timer;

        var timer2 = (timer + klickOffset) % tbb;
        int p1key = (int)Player1Key;
        int p2key = (int)Player2Key;

        if (timer2 < timingAccuracy || timer2 > tbb - timingAccuracy) {
            if (Input.GetKeyDown(p1key.ToString()) && p1canHit) {
                player1.PowerLevel += GainPerHit;
                p1canHit = false;
                StartCoroutine(Flash(flash1));
            }
            if (Input.GetKeyDown(p2key.ToString()) && p2canHit) {
                player2.PowerLevel += GainPerHit;
                p2canHit = false;
                StartCoroutine(Flash(flash2));
            }
        } else {
            p1canHit = true;
            p2canHit = true;
            if (Input.GetKeyDown(p1key.ToString())) {
                player1.PowerLevel -= LossPerHit;
            }
            if (Input.GetKeyDown(p2key.ToString())) {
                player2.PowerLevel -= LossPerHit;
            }
        }

        var timer3 = (progress + circleOffset) % tbb;
        hitCircle1.openness = 1 - (timer3 / tbb);
        hitCircle2.openness = 1 - (timer3 / tbb);
    }

    private Dictionary<Image, Coroutine> _coroutines = new Dictionary<Image, Coroutine>();
    IEnumerator Flash(Image image)
    {
        Coroutine co;
        if (_coroutines.TryGetValue(image, out co)) {
            StopCoroutine(co);
        }

        {
            var c = image.color;
            c.a = 1;
            image.color = c;
        }

        while (image.color.a > 0) {
            var c = image.color;
            c.a  -= flashSpeed * Time.deltaTime;
            image.color = c;
            yield return null;
        }
    }
}
