using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticipant : Participant
{

    
           
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (commence)
        {
            Commence();
            commence = false;
        }
            
    }




    /// <summary>
    /// 
    /// </summary>
    public override void Commence()
    {

        Debug.Log(this.GetType() + " Participant Commence" + transform.name);

        foreach (Participant p in others)
        {
            Debug.Log("  participant other -> " + p.transform.name);
        }
                                                                                    //just handling one for now
        Debug.Log(this.GetType() + " Participant Commence " + transform.name + " " + others[0].GetType());

        //start lookat slerp to other
        transform.GetComponent<CharacterNavigator>().LookAtTarget = others[0].transform;

        //I cant just say "other.testValue" as other is just a base participant (puppy, human, etc...)
        //But what I can do is hard cast to what I might expect, and see if it is one 
        PlayerParticipant ppo = (PlayerParticipant) others[0];  //TODO: foreach
        
        //so if it is one... (should be if in this initial prototyping stage of code)
        if(ppo)
        {
            
            ppo.transform.GetComponent<DialogInteraction>().commence = true;
        }

        transform.GetComponent<DialogInteraction>().commence = true;
        
    }
}
