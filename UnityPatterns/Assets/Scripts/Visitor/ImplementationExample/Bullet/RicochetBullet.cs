


namespace UnityPatterns.Visitor.Implementation
{
    public class RicochetBullet : Bullet
    {
        public override void InterfareWall(Data.WallHolder wall)
        {
            wall.Interfare(this);
        }
    }
}
