using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// the event is the unit that collects participants for the encounter

public class BaseEvent : MonoBehaviour
{

    public BaseEncounter encounter;
     

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("BaseEvent trigger " + other.name);
            encounter.addParticipant( other.transform.GetComponent<Participant>() );
        }

      
    }
}
