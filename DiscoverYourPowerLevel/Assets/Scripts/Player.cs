using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Player : ScriptableObject {

    public int Id;

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
