using UnityEngine;

namespace Creational.Builder.Health
{
    public class HealthNo : Health
    {
        private static Health _instance;

        public override int MaxValue
        {
            get { return 0; }
        }
        public override bool IsZero
        {
            get { return false; }
        }
        public override int Value
        {
            get { return 0; }
        }


        public static Health Instance
        {
            get
            {
                if (_instance != null) return _instance;
                
                GameObject instance = new GameObject("HealthNo", typeof(HealthNo));
                instance.transform.SetAsFirstSibling();

                _instance = instance.GetComponent<HealthNo>();

                return _instance;
            }
        }


        public override void ResetHealth(int amount) { }

        public override void ModifyHealth(int amount) { }
    }
}