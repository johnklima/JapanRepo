using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Mammal
{
    // Start is called before the first frame update
    void Start()
    {
        Health = 10;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(commence)
        {
            Debug.Log("Do Cat Stuff");

            Dog dog = (Dog) others[0];

            if (dog)
            {
                Debug.Log("Cat runs away");
                
                CharacterNavigator nav = transform.GetComponent<CharacterNavigator>();

                Transform places = GameObject.Find("HiddingPlaces").transform;

                //find nearest hiding place 
                float EPSILON = 1000.0f;
                Vector3 pos = transform.position;
                Transform closest = null;

                foreach(Transform hp in places)
                {
                    float dist = Vector3.Distance(pos, hp.position);

                    if (dist < EPSILON )
                    {
                        EPSILON = dist;
                        closest = hp;
                    }
                }


                nav.Target.position = closest.position; 


            }

            commence = false;
        }
        
    }


    public override void DecrementHealth()
    {
        Health -= 2;
    }
    public override void IncrementHealth()
    {
        Health += 2;
    }

}
