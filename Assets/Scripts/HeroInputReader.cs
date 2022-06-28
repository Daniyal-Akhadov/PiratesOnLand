using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Pirates
{
    [RequireComponent(typeof(HeroMover))]
    public class HeroInputReader : MonoBehaviour
    {
        private HeroMover _heroMover;
        private Vector2 _direction;

        private PlayerInput _input;

        private void Awake()
        {
            _heroMover = GetComponent<HeroMover>();
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
            _direction = _input.Player.Movement.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            _heroMover.Move(_direction);
        }
    }
}