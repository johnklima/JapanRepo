using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///the encounter is the type of thing that happens when one or more
/// characters are collected in from an event
/// </summary>
public class BaseEncounter : MonoBehaviour
{

    /// <summary>The participants</summary>
    public List<BaseParticipant> participants;
    /// <summary>how many participants to fire the encounter</summary>
    public int participantsNeeded = 2;
    /// <summary> do it </summary>
    public bool commence = false;
    /// <summary> how many so far </summary>
    private int has = 0;
    

    /// <summary>Adds a participant. Potentially one of many </summary>
    /// <param name="participant">The participant.</param>
    public void addParticipant(BaseParticipant participant)
    {
        Debug.Log("adding " +  participant.transform.name );

        if(has < participantsNeeded)
        {
            participants.Add(participant);
            has++;
        
            //for now I'm looking at just 2 participants, but in the end will want many more
            if(has == participantsNeeded)
            {
                BaseParticipant[] temps = participants.ToArray();
                foreach (BaseParticipant p in participants)
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
