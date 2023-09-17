using UnityEngine;

namespace Creational.AbstractFactory
{
    public interface ISecondEntity
    {
        GameObject Object { get; }
        float Speed { get; set; }


        void ShowMessage(params string[] message);
    }
}