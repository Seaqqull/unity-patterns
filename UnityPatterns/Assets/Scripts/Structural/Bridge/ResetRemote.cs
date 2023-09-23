namespace Structural.Bridge
{
    public class ResetRemote : MovementRemote, IResetRemote
    {
        public void Reset()
        {
            _device.ResetPosition();
        }
    }
}