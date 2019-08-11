using UnityEngine.Events;
using UnityEngine;

public class EventPooler : Pooler, IEventListener
{
    [SerializeField] private EventSO _event;

    private UnityEvent _response = new UnityEvent();

    public EventSO Event { get => _event; }
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
