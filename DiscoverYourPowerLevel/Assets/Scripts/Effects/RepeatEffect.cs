using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/Effect/Repeat")]
public class RepeatEffect : Effect
{
    public int Count;
    public float Interval;

    public bool AllAtOnce;

    public Effect Effect;

    public override void Spawn(Vector3 location)
    {
        GameManager.Instance.StartCoroutineEnum(SpanwObjects(location));
    }

    private IEnumerator SpanwObjects(Vector3 location) {
        for (int i = 0; i < Count; i++) {
            Effect.Spawn(location);

            if (!AllAtOnce) {
                yield return new WaitForSeconds(Interval);
            }
        }
    }
}
