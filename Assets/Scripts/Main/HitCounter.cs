using TMPro;
using UnityEngine;

namespace ShootEm.Main
{
    public class HitCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private int _hitCount;

        public void OnTargetHit() => _text.text = (++_hitCount).ToString();
    }
}
