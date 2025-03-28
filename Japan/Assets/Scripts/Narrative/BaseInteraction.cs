using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this goes on a player, concrete type being what is processed


public class BaseInteraction : MonoBehaviour
{

    //interactions all support LUTs
    private const int cols = 0;
    private const int rows = 0;


    //just a datatype for now in col,row order
    int[,] resultTable;

    public bool commence = false;
    
    
    

    // Start is called before the first frame update
    void Start()
    {

        resultTable = new int[cols, rows];


    }
    public virtual void Commence()
    {
        Debug.Log("BaseInteraction Commence " + transform.name);
        foreach (Participant p in transform.GetComponent<Participant>().others)
        {
            Debug.Log("  interactionPARTICIPANT -> other " + p.transform.name);

            foreach(BaseInteraction i in p.interactions)
            {
                Debug.Log("     interactionPARTICIPANT -> other -> interactions " + i.transform.name);                
            }
        }
    }

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
