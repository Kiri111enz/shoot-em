using UnityEngine;

namespace ShootEm.Utils
{
    public class RestrictedRotator : MonoBehaviour
    {
        [SerializeField] private Vector3 _minRotation = new Vector3(-90f, -90f);
        [SerializeField] private Vector3 _maxRotation = new Vector3(90f, 90f);

        public Vector3 Rotation
        {
            get => _rotation;
            set
            {
                _rotation = new Vector3(
                    Mathf.Clamp(value.x, _minRotation.x, _maxRotation.x),
                    Mathf.Clamp(value.y, _minRotation.y, _maxRotation.y),
                    Mathf.Clamp(value.z, _minRotation.z, _maxRotation.z));
                
                transform.eulerAngles = _rotation;
            }
        }
        private Vector3 _rotation;
    }
}
