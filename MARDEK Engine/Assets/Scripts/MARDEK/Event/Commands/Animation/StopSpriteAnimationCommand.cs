using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MARDEK.Event;

namespace MARDEK.Animation
{
    public class StopSpriteAnimationCommand : CommandBase
    {
        [SerializeField] SpriteAnimator targetAnimator;
        [SerializeField] bool sendStopRate = false;
        [SerializeField, Range(0f, 1f)] float animationStopRate = 1f;

        public override void Trigger()
        {
            if(sendStopRate)
                targetAnimator.StopCurrentAnimation(animationStopRate);
            else
                targetAnimator.StopCurrentAnimation();
        }
    }
}