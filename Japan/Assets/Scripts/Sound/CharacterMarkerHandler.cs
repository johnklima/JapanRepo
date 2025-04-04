using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterMarkerHandler : AudioTimelineMarkerHandler
{

    public ScriptUsageTimeline usageTimeline;
    public FMODUnity.StudioEventEmitter emitter;

    //Depending on usage, we may wish to autostart. If a sound emmiter has a trigger, 
    //a oneshot for example, we probably dont want to autostart
    public bool initAtStart = true;

    /// <summary>
    /// The callback the ScriptUsageTimeline will fire when a marker is hit
    /// </summary>
    /// <param name="marker">The marker name.</param>
    public override void HandleIt(string marker)
    {
        
        Debug.Log(transform.name + " received " + marker );        

    }

    private void Start()
    {
        if(initAtStart && usageTimeline && emitter)
        {
            usageTimeline.StartTimeline(emitter);
        }
        else if(initAtStart)
        {
            Debug.LogWarning("initAtStart is true, but there is no emitter or timeline");
        }
    }


}
