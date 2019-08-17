using UnityEngine;

public abstract class SetToDoSO<T> : ScriptableObject where T : Item<T>
{
    [SerializeField] protected SetSO<Item<T>, T> _set;


    public abstract void ToDo();
}
