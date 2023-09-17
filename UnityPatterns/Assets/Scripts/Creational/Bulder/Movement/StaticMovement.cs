using UnityEngine;


namespace Creational.Builder.Movement
{
    public class StaticMovement : Movement
    {
        private static Movement _instance;

        public static Movement Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                GameObject instance = new GameObject("StaticMovement", typeof(StaticMovement));
                instance.transform.SetAsFirstSibling();

                _instance = instance.GetComponent<StaticMovement>();

                return _instance;
            }
        }
        
        
        public override void Move(Vector3 position) { }
    }
}