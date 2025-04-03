using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    StatePersonAnimationLUT animLUT;

    // Start is called before the first frame update
    void Start()
    {   
        animLUT = new StatePersonAnimationLUT(transform);
    }


}
