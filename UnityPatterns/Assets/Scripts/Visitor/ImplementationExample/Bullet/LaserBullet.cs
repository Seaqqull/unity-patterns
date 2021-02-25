


namespace UnityPatterns.Visitor.Implementation
{
    public class LaserBullet : Bullet
    {
        public override void InterfareWall(Data.WallHolder wall)
        {
            wall.Interfare(this);
        }        
    }
}
