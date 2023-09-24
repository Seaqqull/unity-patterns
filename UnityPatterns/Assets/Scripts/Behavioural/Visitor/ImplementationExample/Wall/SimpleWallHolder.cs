using UnityEngine;


namespace UnityPatterns.Visitor.Implementation
{
    public class SimpleWallHolder : MonoBehaviour, Data.IWallHolder
    {
        [SerializeField] [Range(-5.0f, 5.0f)] private float _impactAmount = 0.5f;


        public void Interfare(LaserBullet bullet)
        {
            Debug.Log("Wall[Simple]: collistion from laser bullet");
            // Destroy bullet
            Destroy(bullet.gameObject);
        }

        public void Interfare(SimpleBullet bullet)
        {
            Debug.Log("Wall[Simple]: collistion from simple bullet");
            // Destroy bullet
            Destroy(bullet.gameObject);
        }

        public void Interfare(RicochetBullet bullet)
        {
            Debug.Log("Wall[Simple]: bullet ricochets");
            // Change angle
            bullet.ApplyForce(-bullet.Body.velocity * _impactAmount);
        }
    }
}
