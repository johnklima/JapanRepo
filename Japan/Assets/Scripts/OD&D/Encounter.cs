using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Encounter : MonoBehaviour
{

    public bool fight = false;
    public List<Fight>  combatants;
    public int playersNeeded = 1;
    private int has = 0;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void addCombatant(Fight fight)
    {
        if(has < playersNeeded)
        {
            combatants.Add(fight);
            has++;
        
            if(has == playersNeeded)
            {
                Fight[] fights = combatants.ToArray();
                foreach (Fight f in combatants)
                {
                    for (int i = 0; i < fights.Length; i++)
                    {
                        if(f != fights[i] && fights[i] != null)
                        {
                            f.enemy = fights[i].player;
                            fights[i] = null;
                        }
                    }
                }

                this.fight = true;
            }
        
        }



    }

    // Update is called once per frame
    void Update()
    {
       if(fight)
       {
            foreach(Fight f in combatants)
            {
                f.fight = true;
            }

            fight = false;
       }
    }
}
