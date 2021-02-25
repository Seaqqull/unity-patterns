using UnityEngine;


namespace UnityPatterns.Visitor
{
    /* Base */
    interface Visitor
    {
        public void Visit(ItemA item);
        public void Visit(ItemB item);
    }

    interface Item
    {
        public void Accept(Visitor visitor);
    }


    /* Example */

    // Visitors
    class VisitorA : Visitor
    {
        public void Visit(ItemA item)
        {
            Debug.Log("Item:A -> visitor:A");
        }

        public void Visit(ItemB item)
        {
            Debug.Log("Item:B -> visitor:A");
        }
    }

    class VisitorB : Visitor
    {
        public void Visit(ItemA item)
        {
            Debug.Log("Item:A -> visitor:B");
        }

        public void Visit(ItemB item)
        {
            Debug.Log("Item:B -> visitor:B");
        }
    }

    // Items
    class ItemA : Item
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }

    class ItemB : Item
    {
        public void Accept(Visitor visitor)
        {
            visitor.Visit(this);
        }
    }
}