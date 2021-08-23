using UnityEngine;

namespace ShootEm
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private Vector2 _mouseSensitivity = new Vector2(0.1f, 0.2f);
        
        [SerializeField] private RestrictedRotator cameraRotator;
        [SerializeField] private Gun _gun;
        
        private InputActions _input;

        private void Awake() => SetUpInput();

        private void OnEnable() => _input.Enable();

        private void OnDisable() => _input.Disable();
        
        private void SetUpInput()
        {
            _input = new InputActions();

            _input.Game.Look.performed += context => 
                cameraRotator.Rotation += context.ReadValue<Vector2>() * _mouseSensitivity;

            _input.Game.Shoot.performed += context => _gun.Shoot();
        }
    }
}
