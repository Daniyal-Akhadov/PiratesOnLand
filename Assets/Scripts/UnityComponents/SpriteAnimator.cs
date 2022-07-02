using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Pirates.Components
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimator : MonoBehaviour
    {
        [SerializeField] private int _frameRate = 10;
        [SerializeField] private SpriteClip[] _spriteClips;

        private SpriteRenderer _renderer;
        private float _secondsPerFrame;
        private int _currentSpriteIndex;
        private float _nextFrameTime;

        private SpriteClip _currentClip;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _currentClip = _spriteClips[_currentSpriteIndex];
            _currentClip.Initialize(_renderer, _frameRate);
        }

        public void Update()
        {
            if (_spriteClips[_currentSpriteIndex].AllowNext && _currentSpriteIndex < _spriteClips.Length - 1)
            {
                _currentClip = _spriteClips[++_currentSpriteIndex];
                SetClip(_currentClip.Name);
            }
            else
            {
                _currentClip.ChangeSprite();
            }
        }

        private void SetClip(string name)
        {
            foreach (var spriteClip in _spriteClips)
            {
                if (spriteClip.Name == name)
                {
                    spriteClip.Initialize(_renderer, _frameRate);
                }
            }
        }
    }
}