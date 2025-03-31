using player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// this goes on a player, concrete type being what is processed
/// </summary>
public abstract class BaseInteraction : MonoBehaviour
{
    /// <summary>
    /// just a 2d array of ints, LUT 
    /// </summary>
    public int[,] resultTable;

    public bool commence = false;

    public abstract void Commence();

}
