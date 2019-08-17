using UnityEngine;

[CreateAssetMenu(menuName = "ToDo/Simple")]
public class SimpleToDoSO : SetToDoSO<SimpleItem>
{
    [Range(0, 10)] public int minSize;
    [Range(0, 10)] public int maxSize;
    [SerializeField] protected new SimpleSetSO _set;


    public override void ToDo()
    {
        if (minSize > maxSize) return;

        for (int i = 0; i < _set.Items.Count; i++)
        {
            _set.Items[i].transform.localScale = new 
                Vector3(Random.Range(minSize, maxSize), Random.Range(minSize, maxSize), Random.Range(minSize, maxSize));
        }
    }
}
