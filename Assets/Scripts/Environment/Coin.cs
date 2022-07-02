using UnityEngine;
using UnityEngine.Events;

namespace Pirates
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private int _value;
        [SerializeField] private UnityEvent _onTaken;

        public int Value => _value;

        public void Take()
        {
            _onTaken?.Invoke();
        }
    }
}