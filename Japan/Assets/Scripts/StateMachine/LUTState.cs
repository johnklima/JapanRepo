using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LUTState : State
{
    /// <summary>
    ///the lookup table
    /// </summary>
    public LUT results;
    /// <summary>
    ///generally the owner of this state
    /// </summary>
    public int row;
    /// <summary>
    ///generally the thing the owner is reacting to
    /// </summary>
    public int col;        

    public override int Process()
    {
        //process children first
        foreach(State child in childStates)
        {
            int childVal = child.Process();
            if (childVal >= 0)
                return childVal;
        }

        //process me
        return results.result(row,col);  
    }
}
