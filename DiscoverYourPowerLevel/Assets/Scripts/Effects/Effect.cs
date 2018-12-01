using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject {

    public abstract void Spawn(Vector3 location);

    public void Spawn() {
        Spawn(Vector3.zero);
    }
}
