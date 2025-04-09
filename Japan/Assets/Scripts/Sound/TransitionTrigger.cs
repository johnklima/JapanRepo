using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionTrigger : MonoBehaviour
{

    public FMODUnity.StudioEventEmitter emitter;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {

            emitter.SetParameter("fight", 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {

            emitter.SetParameter("fight", 0.0f);
        }
    }
}
