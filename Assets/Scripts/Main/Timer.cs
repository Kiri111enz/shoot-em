using System;
using System.Collections;
using TMPro;
using ShootEm.Utils;
using UnityEngine;

namespace ShootEm.Main
{
    public class Timer : Repeater
    {
        [SerializeField] private string _format = @"ss\:ff";
        [SerializeField] private TMP_Text _text;
        [SerializeField] private float _updateFrequency = 0.01f;
        
        [field: SerializeField] public float Time { get; private set; }

        private string TimeText => TimeSpan.FromSeconds(Time).ToString(_format);

        protected override IEnumerator OnRepeat()
        {
            _text.text = TimeText;
            yield return new WaitForSeconds(_updateFrequency);
            Time += _updateFrequency;
        }

        private void Awake() => StartCoroutine(BeginRepeating());
    }
}
