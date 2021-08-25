using UnityEngine;

namespace ShootEm.Main
{
    public class Game : MonoBehaviour
    {
        # if !UNITY_EDITOR
        private void Awake() => Cursor.visible = false;
        #endif
    }
}
