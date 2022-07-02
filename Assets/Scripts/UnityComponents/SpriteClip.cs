using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Pirates.Components
{
    [Serializable]
    public class SpriteClip
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private bool _loop;
        [SerializeField] private UnityEvent _onComplete;

        private float _secondsPerFrame;
        private int _currentSpriteIndex;
        private float _nextFrameTime;
        private SpriteRenderer _renderer;

        public bool AllowNext { get; private set; }
        public string Name => _name;


        public void ChangeSprite()
        {
            if (_nextFrameTime > Time.time)
                return;

            if (_loop)
            {
                _currentSpriteIndex %= _sprites.Length;
            }
            else if (_currentSpriteIndex == _sprites.Length)
            {
                Complete();
                return;
            }

            _renderer.sprite = _sprites[_currentSpriteIndex++];
            _nextFrameTime += _secondsPerFrame;
        }

        public void Initialize(SpriteRenderer renderer, float frameRate)
        {
            _renderer = renderer;
            _secondsPerFrame = 1f / frameRate;
            _nextFrameTime = Time.time + _secondsPerFrame;
            _currentSpriteIndex = 0;
        }

        public void Complete()
        {
            AllowNext = true;
            _onComplete?.Invoke();
        }
    }
}