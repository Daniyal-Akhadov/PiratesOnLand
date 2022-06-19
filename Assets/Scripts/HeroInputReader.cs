using System;
using UnityEngine;

namespace Pirates
{
    [RequireComponent(typeof(HeroMover))]
    public class HeroInputReader : MonoBehaviour
    {
        private HeroMover _heroMover;
        private float _direction;

        private void Awake()
        {
            _heroMover = GetComponent<HeroMover>();
        }

        public void Update()
        {
            _direction = Input.GetAxis("Horizontal");
        }

        private void FixedUpdate()
        {
            _heroMover.Move(_direction);
        }
    }
}