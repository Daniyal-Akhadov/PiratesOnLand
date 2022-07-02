using UnityEngine;

namespace Pirates
{
    public static class HeroAnimation
    {
        public static readonly int IsGround = Animator.StringToHash("IsGround");
        public static readonly int VerticalVelocity = Animator.StringToHash("VerticalVelocity");
        public static readonly int IsRunning = Animator.StringToHash("IsRunning");
    }
}