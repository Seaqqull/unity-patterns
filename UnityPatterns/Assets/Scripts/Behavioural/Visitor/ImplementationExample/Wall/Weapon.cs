using UnityEngine;


namespace UnityPatterns.Visitor.Implementation
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private GameObject Bullet;
        [SerializeField] private Transform ShotPosition;


        public void Shoot()
        {
            var bullet = Instantiate(Bullet);
            
            var bulletTransform = bullet.transform;
            bulletTransform.parent = ShotPosition;
            bulletTransform.localPosition = Vector3.zero;

            var bulletParams = bullet.GetComponent<Bullet>();
            bulletParams.Lunch();
        }
    }
}
