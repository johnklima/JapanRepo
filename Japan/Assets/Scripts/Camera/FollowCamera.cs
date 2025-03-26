using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    public Transform Target;
    public Transform moveTarget;

    public float Height = 3.0f;
    public float Distance = 5.0f;

    public Camera cameraPointer;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Target.position + Vector3.up * Height - Target.forward * Distance;
        transform.LookAt(Target.position);



        if(Input.GetMouseButtonDown(0) )
        {

            // Bit shift the index of the layer to get a bit mask
            int layerMask = 1 << 8; //ground

            RaycastHit hit;

            Ray ray = cameraPointer.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1000, layerMask))
            {
                moveTarget.position = hit.point;
            }

        }
        
    }
}
