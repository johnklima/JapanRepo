using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public List<State> childStates = new List<State>();
    public abstract int Process();

}
