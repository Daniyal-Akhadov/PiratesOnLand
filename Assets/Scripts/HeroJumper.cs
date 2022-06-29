using System;
using UnityEngine;

namespace Pirates
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroJumper : MonoBehaviour
    {
        [SerializeField] private float _force = 200f;

        private Rigidbody2D _rigidbody;

        private bool _isJumping;
        private bool _isGround;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            if (_isJumping == true)
            {
                if (_isGround == true)
                {
                    _rigidbody.AddForce(Vector2.up * _force, ForceMode2D.Impulse);
                    _isGround = false;
                }
            }
            else if (_rigidbody.velocity.y > 0)
            {
                var velocity = _rigidbody.velocity;
                velocity = new Vector2(velocity.x, velocity.y * 0.5f);
                _rigidbody.velocity = velocity;
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Ground _))
            {
                _isGround = true;
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
    }
}