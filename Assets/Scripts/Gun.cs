using System.Collections;
using UnityEngine;

namespace ShootEm
{
    [RequireComponent(typeof(Animator))]
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Transform _shootFrom;
        [SerializeField] private Bullet _bulletPrefab;
        
        [Tooltip("Timeline [0;1] is used.")] [SerializeField] private AnimationCurve _recoilCurve;
        [SerializeField] private float _recoilDuration;
        private float _timeRemaining;

        [SerializeField] private string _fireTriggerName = "Fired";
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_shootFrom.position, transform.forward * 100);
        }
        
        public void Shoot()
        {
            Instantiate(_bulletPrefab, _shootFrom.position, transform.rotation);
            _animator.SetTrigger(_fireTriggerName);

            if (_timeRemaining <= 0)
            {
                _timeRemaining = _recoilDuration;
                StartCoroutine(Recoil());
            }

            _timeRemaining = _recoilDuration;
        }

        private IEnumerator Recoil()
        {
            var lastAngleChange = 0f;
            
            while (_timeRemaining > 0)
            {
                var angleChange = _recoilCurve.Evaluate(1 - _timeRemaining / _recoilDuration);
                transform.Rotate(angleChange - lastAngleChange, 0, 0);
                lastAngleChange = angleChange;
                
                _timeRemaining -= Time.deltaTime;
                yield return null;
            }

            transform.Rotate(_recoilCurve.Evaluate(1) - lastAngleChange, 0, 0);
        }
    }
}
