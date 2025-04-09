using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class DayEvent : MonoBehaviour
{
    /// <summary>
    /// Event Types are all failures
    /// </summary>

    public const int FLARE = 0;
    public const int SIGNAL = 1;
    public const int SATELLITE = 2;
    public const int COMMS = 3;
    public const int EQUIP = 4;

    public int eventType;

    private ADay myDay;

    public string[] eventNames = new string[] 
    {
        "Solar Flare",
        "Unknown Signal from far side of planet",
        "Satellite disappears",
        "Lost comms",
        "Equipment Malfuntion"
    };

    /// <summary>
    /// Initializes a new instance of the <see cref="DayEvent"/> class.
    /// </summary>
    /// <param name="_day">The day.</param>
    public DayEvent(ADay _day)
    {
        eventType = Random.Range(0, 5);
        myDay = _day;
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
