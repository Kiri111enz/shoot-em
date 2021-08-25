using System;
using UnityEngine;

namespace ShootEm.Shooting
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _shootFrom;
        [SerializeField] private Bullet _bulletPrefab;
        
        public event Action Shot;
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_shootFrom.position, transform.forward * 100);
        }
        
        public void Shoot()
        {
            Instantiate(_bulletPrefab, _shootFrom.position, transform.rotation);
            Shot?.Invoke();
        }
    }
}
