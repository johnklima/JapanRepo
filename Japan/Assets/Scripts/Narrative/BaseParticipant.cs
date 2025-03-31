using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  Abstract participant class
/// </summary>
public abstract class BaseParticipant : MonoBehaviour
{

    /// <summary>The other (base) participants in the encounter</summary>
    public List<BaseParticipant> others;
    /// <summary> my interactions in the encounter  </summary>
    public List<BaseInteraction> interactions;
    /// <summary> do it  </summary>
    public bool commence = false;

    /// <summary>Commences interactions for this instance.</summary>
    public abstract void Commence();

 

}
