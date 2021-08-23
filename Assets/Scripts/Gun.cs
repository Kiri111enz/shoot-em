using UnityEngine;

namespace ShootEm
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Vector3 _shootPositionOffset;

        [SerializeField] private Bullet _bulletPrefab;

        private Vector3 ShootPosition => transform.position + _shootPositionOffset;

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ShootPosition, transform.forward * 100);
        }
        
        public void Shoot() => Instantiate(_bulletPrefab, ShootPosition, transform.rotation);
    }
}
