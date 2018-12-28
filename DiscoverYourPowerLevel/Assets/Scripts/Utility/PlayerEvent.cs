using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName="Custom/PlayerEvent")]
public class PlayerEvent : ScriptableObject {

    [SerializeField]
    private List<PlayerEventListener> listeners = new List<PlayerEventListener>();
    
    public void RegisterListerner(PlayerEventListener listener)
    {
        listeners.Add(listener);
    }
 
    public void UnregisterListener(PlayerEventListener listener)
    {
        listeners.Remove(listener);
    }
 
    public void Dispatch(Player player)
    {
        for (int i = listeners.Count - 1; i >= 0; --i)
        {
            listeners[i].OnPlayerEvent(player);
        }
    }
}
