using UnityEngine;

public abstract class Item<T> : MonoBehaviour
{  
    protected abstract SetSO<Item<T>, T> Set { get; }


    private void OnEnable()
    {
        Set.Add(this);
    }

    private void OnDisable()
    {
        Set.Add(this);
    }
}
