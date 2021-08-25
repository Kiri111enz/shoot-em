using System.Collections;
using UnityEngine;

namespace ShootEm.Shooting
{
    internal class GunRecoil : GunAddon
    {
        [Tooltip("Timeline [0;1] is used.")] [SerializeField] private AnimationCurve _curve;
        [SerializeField] private float _duration;
        private float _timeRemaining;

        protected override void OnGunShot()
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
