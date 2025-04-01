using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCone : MonoBehaviour
{
    CharacterNavigator nav;

    // Start is called before the first frame update
    void Start()
    {
         nav = transform.parent.GetComponent<CharacterNavigator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Animal" && other.transform != transform.parent) 
        {
            Debug.Log("thinks he sees " + other.name); 

            RaycastHit hit;
            Vector3 pos = transform.parent.position + Vector3.up;           //parent of the ray cone
            Vector3 dir = (other.transform.position + Vector3.up) - pos;    //direction to seek target

            dir.Normalize();

            // Does the ray intersect any objects excluding the player layer
            if ( Physics.Raycast(pos, dir, out hit, 100.0f) )
            {
                Debug.DrawRay(pos, dir * hit.distance, Color.yellow);
                Debug.Log("hits " + other.name);

                if (hit.transform == other.transform)
                {
                    Debug.Log("he actually ray sees " + other.name);
                   
                    nav.Target = other.transform;
                    nav.agent.isStopped = false;
                }
                else
                {
                   
                    Debug.Log("he ray sees " + hit.transform.name);
                    nav.agent.isStopped = true;
                    nav.Target = nav.transform; //set my goal object to me (the cone parent)
                }
            }
            else
            {
                Debug.Log("he no longer ray sees " + other.name);
                nav.agent.isStopped = true;
                nav.Target = nav.transform; //set my goal object to me (the cone parent)
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Animal" && other.transform != transform.parent)
        {
            Debug.Log("he no longer cones sees " + other.name);
            nav.agent.isStopped = true;
            nav.agent.SetDestination(nav.transform.position);

        }


    }
}
