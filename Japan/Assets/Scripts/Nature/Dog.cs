using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Mammal
{

    public VisionCone vizcone;
    

    // Start is called before the first frame update
    void Start()
    {
        Health = 20;
        prevTarget = transform.GetComponent<CharacterNavigator>().Target;


    }

    private void Update()
    {
        
    }
    
    // LateUpdate is called once per frame
    void LateUpdate()
    {
        if (commence)
        {
            Debug.Log("Do Dog Stuff");

            Cat cat = (Cat) others[0]; 

            if(cat)
            {
                Debug.Log("Dog chases cat");

                vizcone.Target = cat.transform;

            }


            commence = false;
        }

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
