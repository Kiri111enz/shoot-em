using UnityEngine;

namespace ShootEm.Shooting
{
    [RequireComponent(typeof(Gun))]
    [RequireComponent(typeof(Animator))]
    internal class GunAnimator : MonoBehaviour
    {
        [SerializeField] private string _fireTriggerName = "Fired";
        private Animator _animator;
        
        private Gun _gun;
        
        private void Awake()
        {
            _gun = GetComponent<Gun>();
            _animator = GetComponent<Animator>();
        }

        private void OnEnable() => _gun.Shot += OnGunShot;

        private void OnDisable() => _gun.Shot -= OnGunShot;

        private void OnGunShot() => _animator.SetTrigger(_fireTriggerName);
    }
}
