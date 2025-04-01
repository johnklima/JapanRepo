using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : Animal
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
                Vector3 pos;
                CharacterNavigator nav = transform.GetComponent<CharacterNavigator>();

                Transform places = GameObject.Find("HiddingPlaces").transform;

                nav.Target.position = places.GetChild(0).position;


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
