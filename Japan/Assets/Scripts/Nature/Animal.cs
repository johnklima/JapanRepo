using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   <br />
/// </summary>
public abstract class Animal : MonoBehaviour
{
    protected int Health = 10;

    public List<Animal> others;

    public bool commence = false;

    public      Transform targets;
    public      Transform prevTarget;

    public abstract void DecrementHealth();
    public abstract void IncrementHealth();

    public void gotoPeviousTarget()
    {
        transform.GetComponent<CharacterNavigator>().Target = prevTarget;
        //transform.GetComponent<CharacterNavigator>().LookAtTarget = null;
    }


}
