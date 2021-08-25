using UnityEngine;

namespace ShootEm.Shooting
{
    [RequireComponent(typeof(Animator))]
    internal class GunAnimator : GunAddon
    {
        [SerializeField] private string _fireTriggerName = "Fired";
        private Animator _animator;
        
        protected override void OnAwake() => _animator = GetComponent<Animator>();

        protected override void OnGunShot() => _animator.SetTrigger(_fireTriggerName);
    }
}
