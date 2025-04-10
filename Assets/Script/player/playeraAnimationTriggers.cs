using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playeraAnimationTriggers : MonoBehaviour
{
    private player player => GetComponentInParent<player>();

    private void AnimationTrigger() {
        player.AnimationTrigger();

    }
}
