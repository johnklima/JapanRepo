using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;

public class ADay : MonoBehaviour
{
    /// <summary>
    /// The events of this day
    /// </summary>
    public List<DayEvent> Events;
    public int numEvents = 0;

    /// <summary>
    /// Event Types are all failures
    /// </summary>
    public const int FLARE = 0;
    public const int SIGNAL = 1;
    public const int SATELLITE = 2;
    public const int COMMS = 3;
    public const int EQUIP = 4;

    public Transform player;

    public bool dayIsComplete = false;

    /// <summary>
    /// The event names
    /// </summary>
    public string[] eventNames = new string[]
    {
        "Solar Flare",
        "Unknown Signal from far side of planet",
        "Satellite disappears",
        "Lost comms",
        "Equipment Malfuntion"
    };

    /// <summary>
    /// a location for each event corresponding to the events above
    /// </summary>   
    public Transform[] eventLocations = new Transform[5];

    // Start is called before the first frame update
    void Start()
    {
        Events = new List<DayEvent>();

        //add required events (eat sleep)


        //between 2 and 5 events per day
        numEvents = Random.Range(1, 4);

        for(int e = 0; e < numEvents; e++)
        {
            DayEvent devent = new DayEvent(this);
            Debug.Log("New Event " + eventNames[devent.eventType]);
            Events.Add(devent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int total = Events.Count;
        foreach (DayEvent e in Events)
        {
            if(e.isFixed)
            {
                total--;
            }
        
            if(total == 0 && dayIsComplete == false)
            {
                dayIsComplete = true;
                Debug.Log("Day is Complete");
                NextDay();
            }
        
        }        
    }

    private void NextDay()
    {
        //adjust player stats by event
        MattPlayer mp = player.GetComponent<MattPlayer>();

        Debug.Log(mp.name);

        foreach (DayEvent e in Events)
        {
            Debug.Log(e.eventName);

            mp.skillValue[e.eventType]++;

            if(e.eventType == COMMS)
            {
                mp.Sanity++;
            }
            if (e.eventType == SIGNAL)
            {
                mp.StationSanity++;
            }
            

        }
              

        //TODO: this need cleaning/rethinking
        GameObject day = GameObject.Instantiate(transform.gameObject, transform.parent);
        
        ADay newDay = day.GetComponent<ADay>();

        foreach(Transform t in newDay.eventLocations)
        {
            t.GetComponent<EventLocation>().Today = newDay.transform;

        }




        transform.gameObject.SetActive(false);
        this.enabled = false;

    }
}
