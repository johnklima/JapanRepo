using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    public Transform destination;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        TeleportHandler handler = other.transform.GetComponent<TeleportHandler>();

        if (handler != null)
        {
           handler.HandleIt(destination);
        }
        else
        {

            Debug.LogWarning("other does not have a handler");
        }
    }
}
