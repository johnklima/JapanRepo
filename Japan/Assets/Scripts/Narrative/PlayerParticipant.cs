using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParticipant : Participant
{

    public int testValue;

       
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
        Debug.Log("PlayerParticipant Commence " + transform.name);
        
        //I cant just say "other.testValue" as other is just a base participant (puppy, human, etc...)
        //But what I can do is hard cast to what I might expect, and see if it is one 
        PlayerParticipant ppo = (PlayerParticipant) others[0];  //TODO: foreach
        
        //so if it is one...
        if(ppo)
            Debug.Log("   -> other.testValue " + ppo.testValue );

        base.Commence();
    }
}
