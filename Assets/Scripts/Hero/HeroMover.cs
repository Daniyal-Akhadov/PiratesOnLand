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

        public void Move(float direction)
        {
            _rigidbody.velocity = new Vector2(direction * _speed * Time.fixedDeltaTime, _rigidbody.velocity.y);
        }
    }
}