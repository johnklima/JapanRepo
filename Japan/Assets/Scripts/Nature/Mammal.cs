using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mammal : Animal
{


    public override void DecrementHealth()
    {
        Health -= 1;
    }
    public override void IncrementHealth()
    {
        Health += 1;
    }
}
