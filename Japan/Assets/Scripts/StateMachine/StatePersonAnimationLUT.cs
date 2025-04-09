using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


/// <summary>
/// A concrete animation LUT for a specific type of character, who already has a specific
/// animator tree, with specific params
/// </summary>
public class StatePersonAnimationLUT : AnimationLUT
{
    /// <summary>
    /// The Animation Params
    /// </summary>
    public const int CHAT       = 0;
    public const int BOW        = 1;
    public const int FLIRT      = 2;
    public const int INSULT     = 3;
    public const int BLESS      = 4;
    public const int WHISPER    = 5;
    public const int AGRO       = 6;
    public const int SNOB       = 7;
    public const int IGNORE     = 8;

    /// <summary>
    /// The Character Types
    /// </summary>
    public const int GEISHA     = 0;   
    public const int NINJA      = 1;
    public const int GRUNT      = 2;
    public const int WARRIOR    = 3;
    public const int SENSEI     = 4;
    public const int MAN        = 5;
    public const int WOMAN      = 6;
    
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
            {   
                "chat"      ,
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
            resultTable[GEISHA, GEISHA]     = CHAT;      
            resultTable[GEISHA, SENSEI]     = BOW;      
            resultTable[GEISHA, NINJA]      = FLIRT;
            resultTable[GEISHA, GRUNT]      = IGNORE;
            resultTable[GEISHA, WARRIOR]    = FLIRT;
            resultTable[GEISHA, MAN]        = INSULT;
            resultTable[GEISHA, WOMAN]      = INSULT;

            
            //Ninja
            resultTable[NINJA, GEISHA]      = FLIRT;
            resultTable[NINJA, SENSEI]      = AGRO;
            resultTable[NINJA, NINJA]       = WHISPER;
            resultTable[NINJA, GRUNT]       = INSULT;
            resultTable[NINJA, WARRIOR]     = IGNORE;
            resultTable[NINJA, MAN]         = CHAT;
            resultTable[NINJA, WOMAN]       = CHAT;

            //Grunt
            resultTable[GRUNT, GEISHA]      = FLIRT;
            resultTable[GRUNT, SENSEI]      = CHAT;
            resultTable[GRUNT, NINJA]       = WHISPER;
            resultTable[GRUNT, GRUNT]       = AGRO;
            resultTable[GRUNT, WARRIOR]     = CHAT;
            resultTable[GRUNT, MAN]         = INSULT;
            resultTable[GRUNT, WOMAN]       = INSULT;

            //Warrior
            resultTable[WARRIOR, GEISHA]    = FLIRT;
            resultTable[WARRIOR, SENSEI]    = CHAT;
            resultTable[WARRIOR, NINJA]     = IGNORE;
            resultTable[WARRIOR, GRUNT]     = CHAT;
            resultTable[WARRIOR, WARRIOR]   = CHAT;
            resultTable[WARRIOR, MAN]       = INSULT;
            resultTable[WARRIOR, WOMAN]     = INSULT;

            //Sensei
            resultTable[SENSEI, GEISHA]     = SNOB;
            resultTable[SENSEI, SENSEI]     = CHAT;
            resultTable[SENSEI, NINJA]      = IGNORE;
            resultTable[SENSEI, GRUNT]      = CHAT;
            resultTable[SENSEI, WARRIOR]    = CHAT;
            resultTable[SENSEI, MAN]        = BLESS;
            resultTable[SENSEI, WOMAN]      = BLESS;


            //Vil Man
            resultTable[MAN, GEISHA]        = BOW;
            resultTable[MAN, SENSEI]        = BOW;
            resultTable[MAN, NINJA]         = WHISPER;
            resultTable[MAN, GRUNT]         = BOW;
            resultTable[MAN, WARRIOR]       = BOW;
            resultTable[MAN, MAN]           = CHAT;
            resultTable[MAN, WOMAN]         = FLIRT;

            //Vil Woman
            resultTable[WOMAN, GEISHA]      = BOW;
            resultTable[WOMAN, SENSEI]      = BOW;
            resultTable[WOMAN, NINJA]       = WHISPER;
            resultTable[WOMAN, GRUNT]       = BOW;
            resultTable[WOMAN, WARRIOR]     = BOW;                
            resultTable[WOMAN, MAN]         = FLIRT;
            resultTable[WOMAN, WOMAN]       = CHAT;

            save();
        }
    }
}
