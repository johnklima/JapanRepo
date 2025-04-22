using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentTeleportHandler : TeleportHandler
{
    public override void HandleIt(Transform destination)
    {
        NavMeshAgent agent = transform.GetComponent<NavMeshAgent>();

        CharacterNavigator navg = transform.GetComponent<CharacterNavigator>();

        agent.Warp(destination.position);
        agent.SetDestination(destination.position);
        navg.Target.position = destination.position;
    }
}
