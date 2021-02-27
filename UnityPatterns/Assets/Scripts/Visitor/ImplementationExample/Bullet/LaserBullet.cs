


namespace UnityPatterns.Visitor.Implementation
{
    public class LaserBullet : Bullet
    {
        public override void InterfareWall(Data.IWallHolder wall)
        {
            wall.Interfare(this);
        }        
    }
}
