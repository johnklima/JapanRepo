using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    CharacterNavigator nav;
    Animal animal;

    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {
         nav = transform.parent.GetComponent<CharacterNavigator>();
         animal = transform.parent.GetComponent<Animal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform == Target)    //set from encounter (usually) 
        {
            Debug.Log("thinks s/he sees " + other.name); 

            RaycastHit hit;
            Vector3 pos = transform.parent.position + Vector3.up;  //parent of the ray cone
            Vector3 dir = (Target.position + Vector3.up) - pos;    //direction to seek target

            dir.Normalize();

            // Does the ray intersect any objects excluding the player layer
            if ( Physics.Raycast(pos, dir, out hit, 100.0f) )
            {
                Debug.DrawRay(pos, dir * hit.distance, Color.yellow);
                Debug.Log("hits " + Target.name);

                if (hit.transform == Target)
                {
                    Debug.Log("s/he actually ray sees " + Target.name);
                   
                    nav.Target = Target;
                    nav.agent.isStopped = false;
                }
                else
                {
                   
                    Debug.Log("s/he ray sees " + hit.transform.name);
                    StartCoroutine(Countdown(1));
                }
            }
            else  //hits nothing
            {
                Debug.Log("s/he no longer ray sees " + Target.name);
                StartCoroutine(Countdown(1));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == Target)
        {
            Debug.Log("he no longer cones sees " + other.name);
            StartCoroutine( Countdown(1) );

        }


    }

    void DoStuff()
    {
        // Whatever you want to happen when the countdown finishes
        animal.gotoPeviousTarget();
    }

    IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        DoStuff();
    }
}
