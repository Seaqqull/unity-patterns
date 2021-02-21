using UnityEngine.Events;
using UnityEngine;


namespace UnityPatterns.Pooling
{
    public class EventPooler : Pooler, Events.IEventListener
    {
        [SerializeField] private Events.EventSO _event;

        private UnityEvent _response = new UnityEvent();

        public Events.EventSO Event { get => _event; }
        public UnityEvent Response { get => _response; }


        public void OnEnable()
        {
            if (Event == null) return;

            Event.RegisterListener(this);
        }

        public void OnDisable()
        {
            if (Event == null) return;

            Event.UnregisterListener(this);
        }

        public override void Awake()
        {
            base.Awake();

            if (Event != null)
                Response.AddListener(() => this.Pool());
        }


        public void OnEventRaised()
        {
            Response.Invoke();
        }
    }
}
