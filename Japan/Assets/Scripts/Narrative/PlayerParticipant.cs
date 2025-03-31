using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticipant : BaseParticipant
{

    // Update is called once per frame
    void Update()
    {
        if (commence)
        {
            Commence();
            commence = false;
        }

    }

    public override void Commence()
    {

        Debug.Log(this.GetType() + " Player Participant Commence" + transform.name);

        foreach (BaseParticipant p in others)
        {
            Debug.Log("    " + p.GetType() + " participant other -> " + p.transform.name);
        }
       
        //just handling one-on-one for now, but fully intend to handle multiple participants
        Debug.Log(this.GetType() + " Player Participant Commence " + transform.name + " " + others[0].GetType());

        //start lookat slerp to other
        transform.GetComponent<CharacterNavigator>().LookAtTarget = others[0].transform;

        //commence my interaction - does not matter the type!!!!!!
        transform.GetComponent<BaseInteraction>().commence = true;
        
    }
}
