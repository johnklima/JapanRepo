using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this goes on a player, concrete type being what is processed


public abstract class BaseInteraction : MonoBehaviour
{


    //just a datatype for now in col,row order
    public int[,] resultTable;

    public bool commence = false;

    public abstract void Commence();

    // Update is called once per frame
    void Update()
    {
        if(commence)
        {
            Commence();
            commence = false;
        }
            
    }
}
