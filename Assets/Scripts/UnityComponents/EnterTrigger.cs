using UnityEngine;
using UnityEngine.Events;

namespace Pirates.Components
{
    public class EnterTrigger : MonoBehaviour
    {
        [SerializeField] private string _targetTag;
        [SerializeField] private UnityEvent _action;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(_targetTag))
            {
                _action?.Invoke();
            }
        }
    }
}