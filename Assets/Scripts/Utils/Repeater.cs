using System.Collections;
using UnityEngine;

namespace ShootEm.Utils
{
    public abstract class Repeater : MonoBehaviour
    {
        protected virtual bool ShouldRepeat => true;
        
        protected abstract IEnumerator OnRepeat();

        protected IEnumerator BeginRepeating()
        {
            while (ShouldRepeat)
                yield return StartCoroutine(OnRepeat());
        }
    }
}
