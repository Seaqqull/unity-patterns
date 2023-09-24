using UnityEngine;


namespace Creational.Singleton.Implementation
{
    public class SingletonCaller : MonoBehaviour
    {
        private void Start()
        {
            Debug.Log("First child: call");
            SingletonChildFirst.Instance.SomeMethod();

            Debug.Log("Second child: call");
            SingletonChildSecond.Instance.SomeMethod();
            SingletonChildSecond.Instance.SomeAdditionalMethod();
        }
    }
}
