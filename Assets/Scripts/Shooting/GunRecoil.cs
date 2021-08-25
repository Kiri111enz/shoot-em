using System.Collections;
using UnityEngine;

namespace ShootEm.Shooting
{
    [RequireComponent(typeof(Gun))]
    internal class GunRecoil : MonoBehaviour
    {
        [Tooltip("Timeline [0;1] is used.")] [SerializeField] private AnimationCurve _curve;
        [SerializeField] private float _duration;
        private float _timeRemaining;

        private Gun _gun;

        private void Awake()
        {
            _gun = GetComponent<Gun>();
        }

        private void OnEnable() => _gun.Shot += OnGunShot;

        private void OnDisable() => _gun.Shot -= OnGunShot;

        private void OnGunShot()
        { 
            if (_timeRemaining <= 0) 
            { 
                _timeRemaining = _duration; 
                StartCoroutine(Recoil());
            }

            _timeRemaining = _duration;
        }
        
        private IEnumerator Recoil()
        {
            var lastAngleChange = 0f;
            
            while (_timeRemaining > 0)
            {
                var angleChange = _curve.Evaluate(1 - _timeRemaining / _duration);
                transform.Rotate(angleChange - lastAngleChange, 0, 0);
                lastAngleChange = angleChange;
                
                _timeRemaining -= Time.deltaTime;
                yield return null;
            }

            transform.Rotate(_curve.Evaluate(1) - lastAngleChange, 0, 0);
        }
    }
}
