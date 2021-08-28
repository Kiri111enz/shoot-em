using ShootEm.Shooting;
using UnityEngine;

namespace ShootEm.Main
{
    [RequireComponent(typeof(Target))]
    public class Dummy : MonoBehaviour
    {
        public void OnHit()
        {
            print("OUCH!");
            Destroy(gameObject);
        }
    }
}
