using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu]
public class Player : ScriptableObject {

    public double _powerLevel;
    public double PowerLevel {
        get {
            return _powerLevel;
        }
        set {
            var oldValue = _powerLevel;
            _powerLevel = value;

            if ((int)value > (int)oldValue) {
                OnPowerLevelIncreased?.Invoke(value);
            }
        }
    }

    // events
    public Event<int> OnMultiplierIncreased = new Event<int>();

    public delegate void PowerLevelIncreasedDel(double newLevel);
    public event PowerLevelIncreasedDel OnPowerLevelIncreased;

    public void Start() {
        _powerLevel = 0;
    }
}
