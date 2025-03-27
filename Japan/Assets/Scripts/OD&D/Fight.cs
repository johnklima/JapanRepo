using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//contains the D&D LUT
//resolves combat
//evaluates result
//triggers network retrain

public class Fight : MonoBehaviour
{
    
    
    public PlayerSheet player;
    public PlayerSheet enemy;

    public bool fight = false;
    
    public float survivability;
    public int encounters = 0;

    private const int cols = 6;
    private const int rows = 19;


    //just a datatype for now in col,row order
    int[,] resultTable = new int[cols, rows];

    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetComponent<Player>().playerSheet;

        //just do the first col for now, inverse of D&D armor class (big number is good!)
        resultTable[0, 0] = 1;
        resultTable[0, 1] = 2;
        resultTable[0, 2] = 3;
        resultTable[0, 3] = 4;
        resultTable[0, 4] = 5;
        resultTable[0, 5] = 6;
        resultTable[0, 6] = 7;
        resultTable[0, 7] = 7;
        resultTable[0, 8] = 8;
        resultTable[0, 9] = 8;
        resultTable[0, 10] = 9;
        resultTable[0, 11] = 10;
        resultTable[0, 12] = 11;
        resultTable[0, 13] = 11;
        resultTable[0, 14] = 11;
        resultTable[0, 15] = 12;
        resultTable[0, 16] = 13;
        resultTable[0, 17] = 14;
        resultTable[0, 18] = 15;


    }
    public void Commence()
    {
        //start with sword to sword

        //take my stats compare to his
        int needed = resultTable[player.LVL-1, enemy.AC];
        //roll
        int roll = Random.Range(1, 21);
        //add modifiers
        roll += player.modBySTR();
        roll += player.modByENC();
        
        
        if(roll >= needed)
        {
            enemy.ImHit++;
            player.HitHim++;
        }

        survivability = player.HitHim - player.ImHit;
        encounters++;

        //copy back the result as evidently it's a reference not a pointer?
        transform.GetComponent<Player>().playerSheet = player; 


    }

    // Update is called once per frame
    void Update()
    {
        if(fight)
            Commence();
        fight = false;
    }
}
