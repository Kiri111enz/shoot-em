using UnityEngine;

namespace ShootEm
{
    [RequireComponent(typeof(Camera))]
    public class FirstPersonCamera : MonoBehaviour
    {
        [SerializeField] private Vector2 _minRotation = new Vector2(-90f, -90f);
        [SerializeField] private Vector2 _maxRotation = new Vector2(90f, 90f);
        
        private Camera _camera;

        public Vector2 Rotation
        {
            get => _rotation;
            set
            { 
                _rotation = new Vector2(
                    Mathf.Clamp(value.x, _minRotation.x, _maxRotation.x), 
                    Mathf.Clamp(value.y, _minRotation.y, _maxRotation.y));

                _camera.transform.eulerAngles = new Vector3(-_rotation.y, _rotation.x);
            }
        }
        private Vector2 _rotation;

        private void Awake()
        {
            _camera = GetComponent<Camera>();
        }
    }
}
