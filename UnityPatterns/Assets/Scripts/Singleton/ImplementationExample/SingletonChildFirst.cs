using UnityEngine;

public class SingletonChildFirst : Singleton<SingletonChildFirst>
{
    protected override void AdditionalInitialization()
    {
        base.AdditionalInitialization();
        DontDestroyOnLoad(gameObject);
        Debug.Log("First child: initialization");
    }


    public override void SomeMethod()
    {
        Debug.Log("First child: call method");
    }

}
