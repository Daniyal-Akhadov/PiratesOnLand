using System;
using UnityEngine;

namespace Pirates
{
    public class HeroCoinScore : MonoBehaviour
    {
        private int _score;

        private void TakeCoin(Coin coin)
        {
            var value = coin.Value;

            if (value <= 0)
                throw new ArgumentOutOfRangeException($"Value <= 0: {value}");

            _score += value;
            coin.Take();
            print($"Score: {_score}");
        }


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Coin coin))
            {
                TakeCoin(coin);
            }
        }
    }
}