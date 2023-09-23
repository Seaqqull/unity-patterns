using UnityEngine;


namespace Structural.Bridge
{
    public class MovementRemote : MonoBehaviour, IRemote
    {
        [SerializeField] protected Device _device;
        

        public void MoveUp()
        {
            _device.MoveUp();
        }

        public void MoveDown()
        {
            _device.MoveDown();
        }

        public void MoveLeft()
        {
            _device.MoveLeft();
        }

        public void MoveRight()
        {
            _device.MoveRight();
        }
    }
}