using UnityEngine;

namespace ShootEm
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Vector2 _mouseSensitivity = new Vector2(0.1f, 0.2f);
        
        [SerializeField] private FirstPersonCamera firstPersonCamera;
        
        private InputActions _input;

        private void Awake() => SetUpInput();

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
        
        private void SetUpInput()
        {
            _input = new InputActions();

            _input.Game.Look.performed += context => 
                firstPersonCamera.Rotation += context.ReadValue<Vector2>() * _mouseSensitivity;
        }
    }
}
