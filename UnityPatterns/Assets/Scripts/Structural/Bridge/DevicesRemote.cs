using UnityEngine;
using System;


namespace Structural.Bridge
{
    public class DevicesRemote : MonoBehaviour, IResetRemote
    {
        [SerializeField] private Device[] _devices;


        private void ActionOverDevices(Action<Device> deviceAction)
        {
            foreach (var device in _devices)
                deviceAction(device);
        }
        
        public void MoveUp()
        {
            ActionOverDevices(device => device.MoveUp());
        }

        public void MoveDown()
        {
            ActionOverDevices(device => device.MoveDown());
        }

        public void MoveLeft()
        {
            ActionOverDevices(device => device.MoveLeft());
        }

        public void MoveRight()
        {
            ActionOverDevices(device => device.MoveRight());
        }

        public void Reset()
        {
            ActionOverDevices(device => device.ResetPosition());
        }
    }
}