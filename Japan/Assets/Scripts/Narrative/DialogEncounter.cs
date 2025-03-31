using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEncounter : BaseEncounter
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
            foreach (Participant p in participants)
            {
                //face each p to the center of the encounter BY DEFAULT if there is nothing better to look at
                p.transform.GetComponent<CharacterNavigator>().LookAtTarget = transform;

                p.commence = true;
                Debug.Log("Dialog Encounter participant commence " + p.name);
            }

            commence = false;
        }
    }
}
