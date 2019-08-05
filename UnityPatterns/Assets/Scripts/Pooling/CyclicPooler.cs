using System.Collections;
using UnityEngine;

public class CyclicPooler : Pooler
{
    [SerializeField] private float _spawnPeriod = 1;

    private Coroutine _poolCoroutine;

    private void OnEnable()
    {
        SetIsActive(true);
    }

    private void OnDisable()
    {
        SetIsActive(false);
    }


    private void SetIsActive(bool isActive)
    {
        if (isActive)
        {
            _poolCoroutine = StartCoroutine("PoolPerforming", _spawnPeriod);
        }
        else if ((!isActive) && (_poolCoroutine != null))
        {
            StopCoroutine(_poolCoroutine);
        }
    }

    private IEnumerator PoolPerforming(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            Pool();
        }
    }
}
