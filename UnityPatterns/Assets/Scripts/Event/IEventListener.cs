using UnityEngine.Events;


namespace UnityPatterns.Events
{
    public interface IEventListener
    {
        EventSO Event { get; }

        UnityEvent Response { get; }

        void OnEnable();

        void OnDisable();

        void OnEventRaised();
    }
}
