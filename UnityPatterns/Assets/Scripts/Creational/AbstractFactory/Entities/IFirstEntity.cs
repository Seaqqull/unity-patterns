using UnityEngine;

namespace Creational.AbstractFactory
{
    public interface IFirstEntity
    {
        GameObject Object { get; }
        float Speed { get; set; }


        void ShowMessage(string message);
    }
}