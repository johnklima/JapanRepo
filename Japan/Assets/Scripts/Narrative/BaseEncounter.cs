using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


// the encounter is the type of thing that happens when one or more
// characters are collected in from an event

public class BaseEncounter : MonoBehaviour
{

    public List<Participant> participants;
    public int participantsNeeded = 2;
    private int has = 0;
    public bool commence = false;

    public void addParticipant(Participant participant)
    {
        Debug.Log("adding " +  participant.transform.name );

        if(has < participantsNeeded)
        {
            participants.Add(participant);
            has++;
        
            if(has == participantsNeeded)
            {
                Participant[] temps = participants.ToArray();
                foreach (Participant p in participants)
                {
                    for (int i = 0; i < temps.Length; i++)
                    {
                        if(p != temps[i] && temps[i] != null)
                        {
                            //match one to the other
                            p.others.Add (temps[i]);  //add first or add all??

                            //null it
                            temps[i] = null;
                        }
                    }
                }

                this.commence = true;
            }
        
        }

    }


}
