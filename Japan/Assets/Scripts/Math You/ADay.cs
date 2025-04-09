using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class ADay : MonoBehaviour
{

    public List<DayEvent> Events;
    public int numEvents = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        Events = new List<DayEvent>();

        //between 2 and 5 events per day
        numEvents = Random.Range(2, 6);

        for(int e = 0; e < numEvents; e++)
        {
            DayEvent devent = new DayEvent(this);
            Debug.Log("New Event " + devent.eventNames[devent.eventType]);
            Events.Add(devent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
