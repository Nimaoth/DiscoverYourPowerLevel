using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Player : ScriptableObject {

    public PlayerEvent MultiplierIncreased;
    public PlayerEvent PowerLevelIncreased;

    private double _powerLevel;
    public double PowerLevel {
        get {
            return _powerLevel;
        }
        set {
            double old = _powerLevel;
            _powerLevel = value;
            if (value > old){ 
                PowerLevelIncreased.Dispatch(this);
            }
        }
    }

    private int _multiplier;
    public int Multiplier {
        get {
            return _multiplier;
        }
        set {
            int old = _multiplier;
            _multiplier = value;
            if (value > old){ 
                MultiplierIncreased.Dispatch(this);
            }
        }
    }

    public void Reset() {
        PowerLevel = 0;
        _multiplier = 1;
    }
}

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
