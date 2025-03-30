using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Participant : MonoBehaviour
{
    
    public List<Participant> others;
    public bool commence = false;
    public List<BaseInteraction> interactions; //my interactions

    public abstract void Commence(); 

}
