

public interface IPoolable
{
    Pooler Pooler { get; set; }

    void PoolIn();
    void PoolOut();    
}