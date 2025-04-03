using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Lookup table for animation param name/indexes given row/col conditions.
/// </summary>
public class AnimationLUT : LUT
{
    /// <summary>
    /// The anim parameter names
    /// </summary>
    public string[] animParamNames;

    public AnimationLUT(Transform owner)
    {
        Name = owner.name;
    }

    public override int result(int _row, int _col)
    {

        return resultTable[_row, _col];

       
    }

    public string getResultParamName(int _row, int _col)
    {
        int r = resultTable[_row, _col];
        return animParamNames[r];
    }
}
