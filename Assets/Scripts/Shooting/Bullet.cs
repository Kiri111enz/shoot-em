using UnityEngine;

namespace ShootEm.Shooting
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Collider))]
    internal class Bullet : MonoBehaviour
    {
        [Tooltip("Rigidbody mass and gravity are NOT ignored!")] [SerializeField] private float _speed;
        [SerializeField] private float _selfDestructionDelay = 5;
        
        private void Awake()
        {
            GetComponent<Rigidbody>().AddForce(transform.forward * _speed, ForceMode.Impulse);
            Destroy(gameObject, _selfDestructionDelay);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent(out Target target))
                target.Hit.Invoke();
            
            Destroy(gameObject);
        }
    }
}
