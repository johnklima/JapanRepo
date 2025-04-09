using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerMarkerHandler : AudioTimelineMarkerHandler
{

    public ScriptUsageTimeline usageTimeline;
    public FMODUnity.StudioEventEmitter emitter;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void HandleIt(string marker)
    {

        Debug.Log(transform.name + " received " + marker);

    }
}
