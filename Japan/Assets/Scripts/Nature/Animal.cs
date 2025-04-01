using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    protected int Health = 10;

    public List<Animal> others;

    public bool commence = false;

    public abstract void DecrementHealth();
    public abstract void IncrementHealth();

}
