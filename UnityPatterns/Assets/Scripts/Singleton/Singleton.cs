using UnityEngine;


namespace UnityPatterns.Singletons
{
    public class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        protected static T _instance;

        private bool _dataInitialized;

        /// <summary>
        /// Instance of each Singleton<T> class
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_instance != null) return _instance;

                GameObject instance = new GameObject(typeof(T).ToString(), typeof(T));
                instance.transform.SetAsFirstSibling();

                _instance = instance.GetComponent<T>();

                if (!_instance._dataInitialized)
                    _instance.AdditionalInitialization();

                return _instance;
            }
        }


        protected void Awake()
        {
            if (_instance == null)
            {
                _instance = (T)this;
                if (!_dataInitialized) AdditionalInitialization();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        /// <summary>
        /// Child classes will have additional initialization operations
        /// </summary>
        protected virtual void AdditionalInitialization()
        {
            _dataInitialized = true;
            Debug.Log("Singleton: initialization");
        }


        public virtual void SomeMethod()
        {
            Debug.Log("Singleton: method call ");
        }

    }
}