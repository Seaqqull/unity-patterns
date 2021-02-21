using System.Collections;
using UnityEngine;


namespace UnityPatterns.Pooling
{
    public class PeriodicPooler : Pooler
    {
        [SerializeField] private float _spawnPeriod = 1;
        [SerializeField] private bool _isEndless = true;

        private Coroutine _poolCoroutine;
        private int _pooledAmount;

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
                _pooledAmount = 0;
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

                if (_isEndless)
                {
                    Pool();
                }
                else if (_pooledAmount < _poolAmount)
                {
                    Pool();
                    _pooledAmount++;
                }

            }
        }


        public void ResetPool()
        {
            _pooledAmount = 0;
            for (int i = 0; i < _poolAmount; i++)
            {
                PoolCreate();
            }
        }
    }
}
