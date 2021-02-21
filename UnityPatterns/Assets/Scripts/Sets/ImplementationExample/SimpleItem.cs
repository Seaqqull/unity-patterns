using UnityEngine;


namespace UnityPatterns.Sets.Implementation
{
    public class SimpleItem : Item<SimpleItem>
    {
        [SerializeField] private SimpleSetSO _set;

        protected override SetSO<Item<SimpleItem>, SimpleItem> Set => this._set;
    }
}
