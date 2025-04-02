using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterNavigator : MonoBehaviour
{

    public Transform Target;
    public NavMeshAgent agent;
    public Transform LookAtTarget;

    CharacterAnimator animate;

    public float velo;
    public float maxSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();  
        animate = transform.GetComponent<CharacterAnimator>();
        agent.SetDestination(Target.position);      

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance > 1.0f)
        {
            agent.isStopped = false;
            agent.SetDestination(Target.position);
        }  
        else if(Vector3.Distance(Target.position,transform.position) > 1.0f )
        {
            agent.isStopped = false;
            agent.SetDestination(Target.position);
        }
        else
        {
            agent.isStopped = true;
        }
            


        velo = agent.velocity.magnitude;
        

        animate.SetFloatParameter("velocity", velo / maxSpeed);

        //generic way to handle lookat, once at destination, regardless of other states (dialog, etc..)
        if (LookAtTarget && agent.isStopped)
        {
            //simple slerp a facing
            Vector3 tpos = LookAtTarget.position;
            Quaternion rot = transform.rotation;
            transform.LookAt(tpos);
            Quaternion rot2 = transform.rotation;
            transform.rotation = Quaternion.Slerp(rot, rot2, Time.deltaTime * 6.0f); //make it quick


        }
            


    }
}
