using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class AudioTimelineMarkerHandler : MonoBehaviour
{

    public ScriptUsageTimeline usageTimeline;
    public FMODUnity.StudioEventEmitter emitter;

    abstract public void HandleIt(string marker);
    
}
