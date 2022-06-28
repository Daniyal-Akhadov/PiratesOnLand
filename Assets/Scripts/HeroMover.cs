using System;
using UnityEngine;

namespace Pirates
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 direction)
        {
            _rigidbody.velocity = direction * (_speed * Time.fixedDeltaTime);
        }
    }
}