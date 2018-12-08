using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour {

    public GameEvent Event;
    public UnityEvent UnityEvent;

    private void OnEnable()
    {
        Event.RegisterListerner(this);
    }
 
    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void RaiseEvent() {
        UnityEvent.Invoke();
    }
}
