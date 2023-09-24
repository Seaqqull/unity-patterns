using UnityEngine;


namespace UnityPatterns.Visitor.Implementation
{
    public class ClothWallHolder : MonoBehaviour, Data.IWallHolder
    {
        [SerializeField] [Range(-5.0f, 5.0f)] private float _slowdownSpeed = 0.5f;


        public void Interfare(LaserBullet bullet)
        {
            Debug.Log("Wall[Cloth]: penetration from laser bullet");
            // Decrease speed
            bullet.ApplyForce(-bullet.Transform.forward * _slowdownSpeed);
        }

        public void Interfare(SimpleBullet bullet)
        {
            Debug.Log("Wall[Cloth]: collision from simple bullet");
            // Destroy bullet
            Destroy(bullet.gameObject);
        }

        public void Interfare(RicochetBullet bullet)
        {
            Debug.Log("Wall[Cloth]: collision from bullet ricochets");
            // No additional action
        }
    }
}
