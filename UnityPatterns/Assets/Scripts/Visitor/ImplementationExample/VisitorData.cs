


namespace UnityPatterns.Visitor.Implementation.Data
{
    public interface WallHolder
    {        
        public void Interfare(LaserBullet bullet);
        public void Interfare(SimpleBullet bullet);
        public void Interfare(RicochetBullet bullet);
    }


    public interface Bullet
    {
        public void InterfareWall(WallHolder wall);
    }
}