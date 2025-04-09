using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootState : State
{
    /// <summary>
    /// Processes this instance of a Root State.
    /// Root states simply start the DAG down its recursion 
    /// </summary>
    /// <returns>int state value </returns>
    public override int Process()
    {
        int state = -1;
        foreach(State child in childStates)
        {
            state = child.Process();
            if(state >= 0)
            {
                return state;
            }
        }
        return state;
    }
}
