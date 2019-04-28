﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulEater : MonoBehaviour
{

    private MobBehaviourNodes mb;
    private void Start()
    {
        mb = transform.GetComponentInParent<MobBehaviourNodes>();   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
            if (mb.ownerId == 1)
                mb.Owner.GetComponent<PlayerControllsNodes>().health += 450;
            else mb.Owner.GetComponent<AINode>().health += 450;

            Destroy(other.gameObject);


        }
    }
}

