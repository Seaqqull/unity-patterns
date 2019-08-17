using System.Collections.Generic;
using UnityEngine;

public abstract class SetSO<T, Y> : ScriptableObject where T : Item<Y>
{
    [SerializeField] protected List<T> _items = 
        new List<T>();

    protected IReadOnlyList<T> _itemsRestricted;

    public IReadOnlyList<T> Items
    {
        get
        {
            return this._itemsRestricted ??
                (this._itemsRestricted = _items);
        }
    }


    public void Add(T item)
    {
        if (!_items.Contains(item))
            _items.Add(item);
    }

    public void Remove(T item)
    {
        if (!_items.Contains(item))
            _items.Remove(item);
    }
}
