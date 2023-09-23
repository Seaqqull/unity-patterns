namespace Structural.Bridge
{
    public interface IDevice
    {
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();

        void ResetPosition();
    }
}