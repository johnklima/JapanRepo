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
       

    }
    /// <summary>
    /// Sets the float parameter for velocity (idle, walk, run).
    /// </summary>
    /// <param name="parm">The parm.</param>
    /// <param name="val">The value.</param>
    public void SetFloatParameter(string parm, float val)
    {
        anim.SetFloat(parm, val);

    }


}
