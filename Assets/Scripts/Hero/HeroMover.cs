using UnityEngine;

namespace Pirates
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class HeroMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
            _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        }

        public void Move(float direction)
        {
            _animator.SetBool(HeroAnimation.IsRunning, Mathf.Abs(direction) > 0);
            _rigidbody.velocity = new Vector2(direction * _speed * Time.fixedDeltaTime, _rigidbody.velocity.y);
            UpdateDirection(direction);
        }

        private void UpdateDirection(float direction)
        {
            if (direction == 0)
                return;

            _spriteRenderer.flipX = direction < 0;
        }
    }
}