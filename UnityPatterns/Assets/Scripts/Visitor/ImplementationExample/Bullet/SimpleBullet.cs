


namespace UnityPatterns.Visitor.Implementation
{
    public class SimpleBullet : Bullet
    {
        public override void InterfareWall(Data.WallHolder wall)
        {
            wall.Interfare(this);
        }
    }
}
