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
        private Animator _animator;

        private const float ReducingForce = 0.5f;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
        }

        private void FixedUpdate()
        {
            var isGround = IsGround();

            if (_isJumping == true)
            {
                if (isGround && _rigidbody.velocity.y <= 0.001f)
                {
                    _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                }
            }
            else if (_rigidbody.velocity.y > 0)
            {
                ReduceForceBy(ReducingForce);
            }

            _animator.SetBool(HeroAnimation.IsGround, isGround);
            _animator.SetFloat(HeroAnimation.VerticalVelocity, _rigidbody.velocity.y);
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