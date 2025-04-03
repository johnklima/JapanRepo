using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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







/// <summary>
/// A concrete animation LUT for a specific type of character, who already has a specific
/// animator tree
/// </summary>
public class StatePersonAnimationLUT : AnimationLUT
{
    public const int CHAT       = 0;
    public const int BOW        = 1;
    public const int INSULT     = 2;
    public const int BLESS      = 3;
    public const int WHISPER    = 4;
    public const int AGRO       = 5;
    public const int SNOB       = 6;
    public const int IGNORE     = 7;

    /// <summary>
    /// Initializes a new instance of the <see cref="StatePersonAnimationLUT"/> class.
    /// </summary>
    /// <param name="owner">The owner Transform.</param>
    public StatePersonAnimationLUT(Transform owner) : base(owner)
    {
        //rubber meets road eventually
        rows = 7;
        cols = 7;
        //if I don't have yet a file, build this default one
        if(load() == false)
        {
            animParamNames = new string[]
            {   "chat"      ,
                "bow"       ,
                "flirt"     ,
                "insult"    ,
                "bless"     ,
                "whisper"   ,
                "agro"      ,
                "snob"      ,
                "ignore"
            };

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

            save();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
