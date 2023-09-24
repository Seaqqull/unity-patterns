


namespace UnityPatterns.Visitor.Implementation
{
    public class RicochetBullet : Bullet
    {
        public override void InterfareWall(Data.IWallHolder wall)
        {
            wall.Interfare(this);
        }
    }
}
