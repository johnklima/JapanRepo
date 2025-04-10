using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MattPlayer : MonoBehaviour
{

    public int Health = 5;
    public int Sanity = 5;
    public int StationHealth = 5;
    public int StationSanity = 5;

    /// <summary>
    /// The skill names
    /// </summary>
    public string[] skillNames = new string[]
    {
        "Skill at Solar Flare",
        "Skill at Signals",
        "Skill at Satellite",
        "Skill at Comms",
        "Skill at Equipment"
    };

    public int[] skillValue = new int[] { 1, 1, 1, 1, 1 };

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
