using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Participant : MonoBehaviour
{
    
    public Participant other;
    public bool commence = false;
    public List<BaseInteraction> interactions;

    public virtual void Commence()
    {
        Debug.Log("Participant Commence" + transform.name);

        foreach(BaseInteraction inter in interactions)
        {
            inter.commence = true;
        }
    }

}
