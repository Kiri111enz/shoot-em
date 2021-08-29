using System;
using System.Collections;
using ShootEm.Shooting;
using UnityEngine;

namespace ShootEm.Main
{
    public class Level : MonoBehaviour
    {
        [Header("Goal")] 
        [SerializeField] private int _hitCount;
        [SerializeField] private float _time;
        
        private HitCounter _hitCounter;
        
        private void Awake()
        {
            #if !UNITY_EDITOR
            Cursor.visible = false;
            #endif

            StartCoroutine(LoseOnTimeExpired());
            _hitCounter.HitCountChanged += CheckWin;
        }

        private void OnValidate()
        {
            if (_hitCount > FindObjectsOfType<Target>().Length || _hitCount < 1)
                throw new InvalidLevelException($"Should be: 1 <= {nameof(_hitCount)} <= targets number.");

            if (_time <= 0)
                throw new InvalidLevelException("Time should be bigger than 0.");

            var hitCounters = FindObjectsOfType<HitCounter>();
            
            if (hitCounters.Length != 1)
                throw new InvalidLevelException("There should be one and only one hit counter on the scene.");

            _hitCounter = hitCounters[0];
            
            if (FindObjectsOfType<Level>().Length != 1)
                throw new InvalidLevelException("There should be only one Level script on the scene.");
        }

        private void CheckWin()
        {
            if (_hitCounter.HitCount >= _hitCount)
                End(true);
        }

        private IEnumerator LoseOnTimeExpired()
        {
            yield return new WaitForSeconds(_time);
            End(false);
        }

        private void End(bool won)
        {
            print(won ? "Congrats!" : "You suck!");
            
            _hitCounter.HitCountChanged -= CheckWin;
            Destroy(gameObject);
        }
    }

    public class InvalidLevelException : Exception
    {
        public InvalidLevelException(string message) : base(message) { }
    }
}
