using UnityEngine;

namespace ShootEm.Shooting
{
    [RequireComponent(typeof(Gun))]
    internal abstract class GunAddon : MonoBehaviour
    {
        private Gun _gun;

        private void Awake()
        {
            _gun = GetComponent<Gun>();
            OnAwake();
        }

        private void OnEnable() => _gun.Shot += OnGunShot;

        private void OnDisable() => _gun.Shot -= OnGunShot;
        
        protected virtual void OnAwake() { }
        
        protected abstract void OnGunShot();
    }
}
