using System;
using TMPro;
using UnityEngine;

namespace ShootEm.Main
{
    public class HitCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        public int HitCount
        {
            get => _hitCount;
            private set
            {
                _hitCount = value;
                _text.text = _hitCount.ToString();
                HitCountChanged?.Invoke();
            }
        }
        private int _hitCount;

        public event Action HitCountChanged;

        public void OnTargetHit() => HitCount++;
    }
}
