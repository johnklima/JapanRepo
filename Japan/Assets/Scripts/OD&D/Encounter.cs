using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Encounter : MonoBehaviour
{

    public bool fight = false;
    public Fight comb1;
    public Fight comb2;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(fight)
       {
            comb1.fight = true;
            comb2.fight = true;

            fight = false;
       }
    }
}
