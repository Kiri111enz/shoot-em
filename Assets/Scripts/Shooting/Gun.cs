using System;
using System.Collections;
using UnityEngine;

namespace ShootEm.Shooting
{
    public class Gun : MonoBehaviour
    {
        [Header("Shooting settings")]
        [SerializeField] private Transform _shootFrom;
        [SerializeField] private Bullet _bulletPrefab;
        
        [HideInInspector] public bool CanAim = true;
        [Header("Aim settings")]
        [SerializeField] private Vector3 _deltaPosition;
        [SerializeField] private Vector3 _deltaRotation;
        [SerializeField] private float _duration;
        private Vector3 _initialPosition;
        private Vector3 _aimingPosition;
        private Vector3 _initialRotation;
        private Vector3 _aimingRotation;
        private Coroutine _aimRoutine;

        public bool IsAiming
        {
            get => _isAiming;
            set
            {
                if (!CanAim)
                    return;
                
                _isAiming = value;
                _aimRoutine ??= StartCoroutine(Aim());
            }
        }
        private bool _isAiming;

        private float AimProgress
        {
            get => _aimProgress;
            set => _aimProgress = Mathf.Clamp01(value);
        }
        private float _aimProgress;
        
        public event Action Shot;

        private void Awake()
        {
            var gunTransform = transform;
            
            _initialPosition = gunTransform.localPosition;
            _aimingPosition = _initialPosition + _deltaPosition;
            
            _initialRotation = gunTransform.localEulerAngles;
            _aimingRotation = _initialRotation + _deltaRotation;
        }
        
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(_shootFrom.position, _shootFrom.forward * 100);
        }
        
        public void Shoot()
        {
            if (_aimRoutine != null)
                return;
            
            Instantiate(_bulletPrefab, _shootFrom.position, _shootFrom.rotation);
            Shot?.Invoke();
        }
        
        private IEnumerator Aim()
        {
            var gunTransform = transform;

            while (IsAiming ? AimProgress < 1 : AimProgress > 0)
            {
                AimProgress += Time.deltaTime / _duration * (IsAiming ? 1 : -1);
                
                gunTransform.localPosition = Vector3.Lerp(_initialPosition, _aimingPosition, AimProgress);
                gunTransform.localEulerAngles = Vector3.Lerp(_initialRotation, _aimingRotation, AimProgress);
                
                yield return null;
            }

            _aimRoutine = null;
        }
    }
}
