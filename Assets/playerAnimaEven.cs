using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimEvent : MonoBehaviour
{
    // Start is called before the first frame update

    private player player;

    void Start()
    {
        player = GetComponentInParent<player>();
    }

    // Update is called once per frame
    private void AnimationTrigger()
    {
        player.attackOver();

    }
}
