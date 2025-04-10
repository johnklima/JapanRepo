using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventLocation : MonoBehaviour
{

    //this changes day to day
    public Transform Today;
    public bool isFixedHere;
   

    //things to fix here today
    List<DayEvent> eventsToFix;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFixedHere)
        {
            if (Input.GetKeyDown(KeyCode.E) && eventsToFix.Count > 0)
            {
                DayEvent e = eventsToFix[0];
                ADay day = Today.GetComponent<ADay>();

                Debug.Log("Player fixed " + day.eventNames[e.eventType]);
                e.isFixed = true;

                eventsToFix.Remove(e);
            }
            else if (eventsToFix.Count <= 0 && isFixedHere) 
            {
                Debug.Log("Player fixed all events here for today");
                isFixedHere = false;
            }
        }
        
    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
       {
            
            ADay day = Today.GetComponent<ADay>();

            eventsToFix = new List<DayEvent>();

            foreach(DayEvent e in day.Events)
            {
                               
                if (day.eventLocations[e.eventType] == transform)
                {
                    isFixedHere = true;

                    if (e.isFixed == false)
                    {
                       
                        Debug.Log(e.eventName + " gets fixed here ");
                        eventsToFix.Add(e);
                    }
                    else 
                    {
                        Debug.Log( e.eventName + " is already fixed ");
                    }
                    
                }
            }

            //handle the event for this area, if there is one
       }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isFixedHere = false;
            eventsToFix = new List<DayEvent>();
        }


    }
}
