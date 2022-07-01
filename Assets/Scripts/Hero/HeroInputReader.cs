using UnityEngine;

namespace Pirates
{
    [RequireComponent(typeof(HeroMover))]
    [RequireComponent(typeof(HeroJumper))]
    public class HeroInputReader : MonoBehaviour
    {
        private HeroMover _mover;
        private HeroJumper _jumper;
        private PlayerInput _input;

        private float _direction;

        private void Awake()
        {
            _mover = GetComponent<HeroMover>();
            _jumper = GetComponent<HeroJumper>();
            _input = new PlayerInput();
        }

        private void OnEnable()
        {
            _input.Enable();
        }

        private void OnDisable()
        {
            _input.Disable();
        }

        private void Update()
        {
            _direction = _input.Player.Movement.ReadValue<float>();

            if (_input.Player.Jump.IsPressed())
            {
                _jumper.StartJumping();
            }
            else
            {
                _jumper.StopJumping();
            }
        }

        private void FixedUpdate()
        {
            _mover.Move(_direction);
        }
    }
}