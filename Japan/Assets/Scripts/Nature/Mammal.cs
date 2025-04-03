using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammal : Animal
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void DecrementHealth()
    {
        Health -= 1;
    }
    public override void IncrementHealth()
    {
        Health += 1;
    }
}
