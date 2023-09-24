using UnityEngine;


namespace Creational.Singleton.Implementation
{
    public class SingletonChildSecond : Singleton<SingletonChildSecond>
    {
        protected override void AdditionalInitialization()
        {
            base.AdditionalInitialization();
            Debug.Log("Second child: initialization");
        }


        public override void SomeMethod()
        {
            Debug.Log("Second child: call method");
        }


        public void SomeAdditionalMethod()
        {
            Debug.Log("Second child: call additional method");
        }

    }
}