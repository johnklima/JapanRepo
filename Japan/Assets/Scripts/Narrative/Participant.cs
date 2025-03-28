using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Participant : MonoBehaviour
{
    
    public List<Participant> others;
    public bool commence = false;
    public List<BaseInteraction> interactions; //my interactions

    public virtual void Commence()
    {
        Debug.Log("Participant Commence" + transform.name);

        foreach (Participant p in others)
        {
            Debug.Log("  participant other -> " + p.transform.name);
        }

        foreach(BaseInteraction inter in interactions)
        {
            inter.commence = true;
        }
    }

}
