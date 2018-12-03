using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions {

    public static IEnumerable<Transform> GetChildren(this Transform self) {
        for (int i = 0; i < self.childCount; i++)
            yield return self.GetChild(i);
    }

    public static IEnumerable<GameObject> GetChildren(this GameObject self) {
        for (int i = 0; i < self.transform.childCount; i++)
            yield return self.transform.GetChild(i).gameObject;
    }
}
