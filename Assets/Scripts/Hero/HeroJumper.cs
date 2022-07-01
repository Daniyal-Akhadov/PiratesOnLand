using System;
using Pirates.Components;
using UnityEngine;

namespace Pirates
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroJumper : MonoBehaviour
    {
        [SerializeField] private float _force = 200f;
        [SerializeField] private LayerChecker _groundChecker;

        private Rigidbody2D _rigidbody;
        private bool _isJumping;

        private const float ReducingForce = 0.5f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_isJumping == true)
            {
                if (IsGround() && _rigidbody.velocity.y <= 0.001f)
                {
                    _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                }
            }
            else if (_rigidbody.velocity.y > 0)
            {
                ReduceForceBy(ReducingForce);
            }
        }

        public void StartJumping()
        {
            _isJumping = true;
        }

        public void StopJumping()
        {
            _isJumping = false;
        }

        private void ReduceForceBy(float value)
        {
            var velocity = _rigidbody.velocity;
            velocity = new Vector2(velocity.x, velocity.y * value);
            _rigidbody.velocity = velocity;
        }

        private bool IsGround()
        {
            return _groundChecker.IsTouchingLayer;
        }
    }
}