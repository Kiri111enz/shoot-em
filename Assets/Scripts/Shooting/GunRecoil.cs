using System.Collections;
using UnityEngine;

namespace ShootEm.Shooting
{
    internal class GunRecoil : GunAddon
    {
        [Tooltip("Timeline [0;1] is used.")] [SerializeField] private AnimationCurve _curve;
        [SerializeField] private float _aimRecoilReductionCoeff;
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
            Gun.CanAim = false;
            var recoilCoeff = Gun.IsAiming ? 1 / _aimRecoilReductionCoeff : 1;
            var lastAngleChange = 0f;
            
            while (_timeRemaining > 0)
            {
                var angleChange = _curve.Evaluate(1 - _timeRemaining / _duration) * recoilCoeff;
                transform.Rotate(angleChange - lastAngleChange, 0, 0);
                lastAngleChange = angleChange;
                
                _timeRemaining -= Time.deltaTime / recoilCoeff;
                yield return null;
            }

            transform.Rotate(_curve.Evaluate(1) - lastAngleChange, 0, 0);
            Gun.CanAim = true;
        }
    }
}
