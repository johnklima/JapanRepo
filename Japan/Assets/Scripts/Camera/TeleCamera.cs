using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleCamera : MonoBehaviour
{

    public Transform target;
    public Transform source;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = target.position + Vector3.up;
        source.LookAt(pos);
        Vector3 eulers = source.rotation.eulerAngles;
        eulers.y += 180;
        Vector3 eul2 = transform.rotation.eulerAngles;

        transform.rotation = Quaternion.Euler(eul2.x,eulers.y,eul2.z);

    }
}
