﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBaseFSM : StateMachineBehaviour {

    public GameObject NPC;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject opponent;
    public float speed = 2.0f;
    public float rotSpeed = 1.0f;
    public float accuracy = 1.0f;

    public Light spotLight;
    //public Color originalSpotlightColor;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        opponent = NPC.GetComponent<EnemyAI>().GetPlayer();
        opponent = NPC.GetComponent<EnemyAI>().player;
        agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>();

        spotLight = NPC.transform.GetComponent<Light>();
    }


}
