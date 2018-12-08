using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class UnityPlayerEvent : UnityEvent<Player> {}

[Serializable]
public class PlayerEventListener : MonoBehaviour {

    public Player player;
    public PlayerEvent Event;
    public UnityPlayerEvent UnityEvent;

    private void OnEnable()
    {
        Event.RegisterListerner(this);
    }
 
    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnPlayerEvent(Player p) {
        if (player == p) {
            UnityEvent.Invoke(p);
        }
    }
}
