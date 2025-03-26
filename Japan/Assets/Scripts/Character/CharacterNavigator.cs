using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavigator : MonoBehaviour
{

    public Transform Target;
    public NavMeshAgent agent;
    CharacterAnimator animate;

    public float velo;

    // Start is called before the first frame update
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();  
        animate = transform.GetComponent<CharacterAnimator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        agent.SetDestination(Target.position);

        velo = agent.velocity.magnitude;
        float max = agent.speed;

        animate.SetFloatParameter("velocity", velo / max);


    }
}
