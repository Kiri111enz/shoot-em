using TMPro;
using UnityEngine;

namespace ShootEm.Main
{
    public class HitCounter : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        public int HitCount { get; private set; }

        public void OnTargetHit() => _text.text = (++HitCount).ToString();
    }
}
