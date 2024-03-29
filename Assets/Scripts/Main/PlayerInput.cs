using ShootEm.Shooting;
using ShootEm.Utils;
using UnityEngine;

namespace ShootEm.Main
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
            {
                var rotation = context.ReadValue<Vector2>() * _mouseSensitivity;
                cameraRotator.Rotation += new Vector3(-rotation.y, rotation.x);
            };

            _input.Game.Shoot.performed += context => _gun.Shoot();

            _input.Game.Aim.started += context => _gun.IsAiming = true;
            _input.Game.Aim.canceled += context => _gun.IsAiming = false;
        }
    }
}
