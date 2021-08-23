using UnityEngine;

namespace ShootEm
{
    [RequireComponent(typeof(Animator))]
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Vector3 _shootPositionOffset;

        [SerializeField] private Bullet _bulletPrefab;

        [SerializeField] private string _fireTriggerName = "Fired";
        private Animator _animator;

        private Vector3 ShootPosition => transform.position + _shootPositionOffset;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ShootPosition, transform.forward * 100);
        }
        
        public void Shoot()
        {
            Instantiate(_bulletPrefab, ShootPosition, transform.rotation);
            _animator.SetTrigger(_fireTriggerName);
        }
    }
}
