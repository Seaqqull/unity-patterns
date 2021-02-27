


namespace UnityPatterns.Visitor.Implementation
{
    public class SimpleBullet : Bullet
    {
        public override void InterfareWall(Data.IWallHolder wall)
        {
            wall.Interfare(this);
        }
    }
}
