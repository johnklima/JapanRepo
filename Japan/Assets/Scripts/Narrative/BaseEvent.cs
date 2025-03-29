using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// the event is the unit that collects participants for the encounter

public class BaseEvent : MonoBehaviour
{
    /// <summary>
    /// list of encounters for this event trigger
    /// </summary>
    public List<BaseEncounter> encounters;  
    /// <summary>
    /// which encounter
    /// </summary>
    int which = 0; 

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("BaseEvent trigger " + other.name);
            encounters[which].addParticipant( other.transform.GetComponent<Participant>() );
        }

      
    }
}
