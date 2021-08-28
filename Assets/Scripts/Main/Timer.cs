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
        
        [field: SerializeField] public float Time { get; private set; }

        private string TimeText => TimeSpan.FromSeconds(Time).ToString(_format);

        protected override IEnumerator OnRepeat()
        {
            _text.text = TimeText;
            yield return null;
            Time += UnityEngine.Time.deltaTime;
        }

        private void Awake() => StartCoroutine(BeginRepeating());
    }
}
