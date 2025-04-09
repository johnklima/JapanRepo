using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundTrigger : AudioTimelineMarkerHandler
{
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            emitter.Play();
            usageTimeline.StartTimeline(emitter);


        }
    }

    /// <summary>
    /// The callback the ScriptUsageTimeline will fire when a marker is hit
    /// </summary>
    /// <param name="marker">The marker name.</param>
    public override void HandleIt(string marker)
    {

        Debug.Log("trigger " + transform.name + " received " + marker);

        if(marker.Contains("trigger") )
        {
            Debug.Log("trigger "  + marker);

        }

    }

}
