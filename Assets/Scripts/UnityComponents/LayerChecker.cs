using UnityEngine;

namespace Pirates.Components
{
    [RequireComponent(typeof(Collider2D))]
    public class LayerChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _layer;

        private Collider2D _collider;

        public bool IsTouchingLayer { get; private set; }

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            IsTouchingLayer = _collider.IsTouchingLayers(_layer);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            IsTouchingLayer = _collider.IsTouchingLayers(_layer);
        }
    }
}