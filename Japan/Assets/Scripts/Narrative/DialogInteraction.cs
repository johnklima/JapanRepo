using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogInteraction : BaseInteraction
{
    public override void Commence()
    {
        Debug.Log("DialogInteraction Commence " + transform.name);
        
        base.Commence();
    }
}
