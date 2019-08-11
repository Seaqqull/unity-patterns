using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Event/Create")]
public class EventSO : ScriptableObject
{
    private List<IEventListener> _eventListeners =
        new List<IEventListener>();


    public void Raise()
    {
        for (int i = _eventListeners.Count - 1; i >= 0; i--)
            _eventListeners[i].OnEventRaised();
    }

    public void RegisterListener(IEventListener listener)
    {
        if (!_eventListeners.Contains(listener))
            _eventListeners.Add(listener);
    }

    public void UnregisterListener(IEventListener listener)
    {
        if (_eventListeners.Contains(listener))
            _eventListeners.Remove(listener);
    }
}
