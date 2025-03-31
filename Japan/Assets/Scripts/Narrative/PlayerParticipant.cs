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
            Debug.Log("    " + p.GetType() + " participant other -> " + p.transform.name);
        }
       
        //just handling one-on-one for now, but fully intend to handle multiple participants
        Debug.Log(this.GetType() + " Participant Commence " + transform.name + " " + others[0].GetType());

        //start lookat slerp to other
        transform.GetComponent<CharacterNavigator>().LookAtTarget = others[0].transform;

        //commence my interaction - does not matter the type!!!!!!
        transform.GetComponent<BaseInteraction>().commence = true;
        
    }
}
