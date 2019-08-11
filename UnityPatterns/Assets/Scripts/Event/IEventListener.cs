using UnityEngine.Events;

public interface IEventListener
{
    EventSO Event { get; }

    UnityEvent Response { get; }

    void OnEnable();

    void OnDisable();

    void OnEventRaised();    
}
