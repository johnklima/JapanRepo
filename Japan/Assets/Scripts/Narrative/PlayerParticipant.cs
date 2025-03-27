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

    public override void Commence()
    {
        Debug.Log("PlayerParticipant Commence " + transform.name);
        PlayerParticipant ppo = (PlayerParticipant) other;

        if(ppo)
            Debug.Log("other.testValue " + ppo.testValue );

        base.Commence();
    }
}
