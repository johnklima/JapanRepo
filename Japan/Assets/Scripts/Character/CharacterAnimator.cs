using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("walk");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("run");
            return;
        }

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            anim.SetTrigger("idle");
            return;
        }

    }
}
