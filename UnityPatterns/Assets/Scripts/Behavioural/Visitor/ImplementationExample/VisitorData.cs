


namespace UnityPatterns.Visitor.Implementation.Data
{
    public interface IWallHolder
    {        
        public void Interfare(LaserBullet bullet);
        public void Interfare(SimpleBullet bullet);
        public void Interfare(RicochetBullet bullet);
    }


    public interface IBullet
    {
        public void InterfareWall(IWallHolder wall);
    }
}