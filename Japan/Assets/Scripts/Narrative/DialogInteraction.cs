using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///   <br />
/// </summary>
public class DialogInteraction : BaseInteraction
{
    //interactions all support LUTs
    private const int cols = 7;     //THEM
    private const int rows = 7;     //ME

       

    //this LUT will be an animation LUT based on player to player type

    // ME           ||                                 THEM
    // _____________||__________________________________________________________________________________________
    // PLAYER TYPE  || Geisha   |   Sensei  |  Ninja   | Sam Grnt  | Sam War   |  Village Man  |  Village Woman
    // _____________||__________|___________|__________|___________|___________|_______________|________________
    // Geisha       ||  chat    |    bow    |  flirt   |   ignore  |   flirt   |    insult     |    insult
    // _____________||__________|___________|__________|___________|___________|_______________|________________
    // Sensei       || downlook |   chat    |  insult  |   chat    |   chat    |    bless      |     bless
    // _____________||__________|___________|__________|___________|___________|_______________|________________
    // Ninja        ||  flirt   |   agro    |  whisper |   insult  |  ignore   |    whisper    |    whisper
    // _____________||__________|___________|__________|___________|___________|_______________|________________
    // Sam Grnt     ||  flirt   |   chat    |  whisper |   agro    |   chat    |    insult     |    insult
    // _____________||__________|___________|__________|___________|___________|_______________|________________
    // Sam War      ||  flirt   |   chat    |  ignore  |   chat    |   chat    |    insult     |    insult
    // _____________||__________|___________|__________|___________|___________|_______________|________________
    // Vil Man      ||  bow     |   bow     |  whisper |   bow     |   bow     |    chat       |    flirt
    // _____________||__________|___________|__________|___________|___________|_______________|________________
    // Vil Woman    ||  bow     |   bow     |  whisper |   bow     |   bow     |    flirt      |     chat
    // _____________||__________|___________|__________|___________|___________|_______________|________________


    /// <summary>The anim names</summary>
    public string[] animParamNames = new string[] 
    {   "chat"      , 
        "bow"       , 
        "flirt"     , 
        "insult"    , 
        "bless"     , 
        "whisper"   , 
        "agro"      ,
        "downlook"  ,
        "ignore"
    };


    // Geisha          0
    // Sensei          1
    // Ninja           2
    // Grunt           3
    // Warior          4
    // Village Man     5
    // Village Woman   6

    private void Start()
    {
        resultTable = new int[rows, cols];

        //Geisha
        resultTable[0, 0] = 0;      //Geisha
        resultTable[0, 1] = 1;      //Sensei
        resultTable[0, 2] = 2;
        resultTable[0, 3] = 8;
        resultTable[0, 4] = 2;
        resultTable[0, 5] = 3;
        resultTable[0, 6] = 3;

        //Sensei
        resultTable[1, 0] = 7;
        resultTable[1, 1] = 0;
        resultTable[1, 2] = 3;
        resultTable[1, 3] = 0;
        resultTable[1, 4] = 0;
        resultTable[1, 5] = 4;
        resultTable[1, 6] = 4;

        //Ninja
        resultTable[2, 0] = 2;
        resultTable[2, 1] = 6;
        resultTable[2, 2] = 5;
        resultTable[2, 3] = 3;
        resultTable[2, 4] = 8;
        resultTable[2, 5] = 5;
        resultTable[2, 6] = 5;

        //Grunt
        resultTable[3, 0] = 2;
        resultTable[3, 1] = 0;
        resultTable[3, 2] = 5;
        resultTable[3, 3] = 6;
        resultTable[3, 4] = 0;
        resultTable[3, 5] = 3;
        resultTable[3, 6] = 3;

        //Warrior
        resultTable[4, 0] = 2;
        resultTable[4, 1] = 0;
        resultTable[4, 2] = 8;
        resultTable[4, 3] = 0;
        resultTable[4, 4] = 0;
        resultTable[4, 5] = 3;
        resultTable[4, 6] = 3;

        //Vil Man
        resultTable[5, 0] = 1;
        resultTable[5, 1] = 1;
        resultTable[5, 2] = 5;
        resultTable[5, 3] = 1;
        resultTable[5, 4] = 1;
        resultTable[5, 5] = 1;
        resultTable[5, 6] = 2;

        //Vil Woman
        resultTable[6, 0] = 1;
        resultTable[6, 1] = 1;
        resultTable[6, 2] = 5;
        resultTable[6, 3] = 1;
        resultTable[6, 4] = 1;
        resultTable[6, 5] = 2;
        resultTable[6, 6] = 0;

    }

    /// <summary>Commences this instance.</summary>
    public override void Commence()
    {
        int me = transform.GetComponent<Person>().typeOfPerson;
        int they = 0;

        Debug.Log("DialogInteraction Commence " + transform.name);
        foreach (BaseParticipant p in transform.GetComponent<BaseParticipant>().others)
        {
            Debug.Log(this.name + " interaction PARTICIPANT -> other " + p.transform.name);
            they = p.transform.GetComponent<Person>().typeOfPerson;
        }

        int result = resultTable[me, they];
        Debug.Log("PLAY " + animParamNames[result]);
        transform.GetComponent<Animator>().SetTrigger(animParamNames[result]);
    }

    private void Update()
    {
        if (commence)
        {
            Commence();
            commence = false;
        }
            
    }
}
