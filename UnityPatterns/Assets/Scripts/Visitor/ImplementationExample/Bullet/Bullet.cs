using UnityEngine;


namespace UnityPatterns.Visitor.Implementation
{
    public abstract class Bullet : MonoBehaviour, Data.IBullet
    {
        [SerializeField] protected float _speed;
        [SerializeField] protected float _range;
        
        [SerializeField] protected bool _lookRotation;
        
        protected bool _isAwakeInited;
        protected bool _isStartInited;
        protected bool _isLaunched;

        protected Vector3 _startPosition;
        protected Rigidbody _rigidbody;

        public Rigidbody Body 
        { 
            get { return _rigidbody; } 
        }
        public Vector3 Position
        {
            get { return Transform.position; }
        }
        public Transform Transform
        {
            get;
            private set;
        }


        protected virtual void Awake()
        {
            InitAwake();
        }

        protected virtual void Start()
        {
            InitStart();
        }

        protected virtual void FixedUpdate()
        {
            if (!_isAwakeInited) InitAwake();
            if (!_isStartInited) InitStart();

            if ((!_isLaunched) ||
                (_speed == 0.0f)) return;

            if (PassedDistance())
                OnBulletDestroy();

            if (_lookRotation && _rigidbody.velocity != Vector3.zero)
            {
                Transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            }
        }


        protected bool PassedDistance()
        {
            return (_range < 0.0f) ? false :
                (_startPosition - Position).sqrMagnitude > _range;
        }

        protected virtual void InitAwake()
        {
            _isAwakeInited = true;

            Transform = transform;
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected virtual void InitStart()
        {
            _isStartInited = true;

            _startPosition = Transform.position;
            _rigidbody.AddForce(Transform.forward * _speed);
        }

        protected virtual void OnBulletDestroy()
        {
            Destroy(gameObject);
        }


        public void Lunch()
        {
            _isLaunched = true;
        }

        public void ApplyForce(Vector3 force)
        {
            _rigidbody.AddForce(force * _speed);
        }


        /// <summary>
        /// Visitor's interaction method
        /// </summary>
        /// <param name="wall">Specific visitor</param>
        public abstract void InterfareWall(Data.IWallHolder wall);
    }
}
