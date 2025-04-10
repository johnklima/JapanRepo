using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Simple class to hold Daily Event data
/// </summary>
public class DayEvent : MonoBehaviour 
{ 

    public int eventType;
    public bool isFixed = false;
    public string eventName;

    private ADay myDay;           

    /// <summary>
    /// Initializes a new instance of the <see cref="DayEvent"/> class.
    /// </summary>
    /// <param name="_day">The day.</param>
    public DayEvent(ADay _ADay)
    {
        //pick a random event type
        eventType = Random.Range(0, 5);
        myDay = _ADay;
        eventName = _ADay.eventNames[eventType];
    }
    
}
