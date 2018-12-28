using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(Player))]
public class PlayerEditor : Editor {
    public override void OnInspectorGUI() {
        DrawDefaultInspector();

        Player p = (Player)target;

        EditorGUILayout.IntField("Power Level", (int)p.PowerLevel);
        if (GUILayout.Button("Increase Power Level")) {
            p.PowerLevel += 1000;
        }


        EditorGUILayout.IntField("Multiplier", p.Multiplier);
        if (GUILayout.Button("Increase Multiplier")) {
            p.Multiplier++;
        }

        GUILayout.Space(20);
        if (GUILayout.Button("Reset")) {
            p.Reset();
        }
    }
}
