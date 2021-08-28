using UnityEngine;

namespace ShootEm.Shooting
{
    [RequireComponent(typeof(Gun))]
    internal abstract class GunAddon : MonoBehaviour
    {
        protected Gun Gun { get; private set; }

        private void Awake()
        {
            Gun = GetComponent<Gun>();
            OnAwake();
        }

        private void OnEnable() => Gun.Shot += OnGunShot;

        private void OnDisable() => Gun.Shot -= OnGunShot;
        
        protected virtual void OnAwake() { }
        
        protected abstract void OnGunShot();
    }
}
