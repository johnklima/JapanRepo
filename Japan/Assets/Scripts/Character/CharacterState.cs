using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState : MonoBehaviour
{
    StatePersonAnimationLUT animLUT;
    State rootState = new RootState(); 
    // Start is called before the first frame update
    void Start()
    {   
        //make the animation table, this is very concrete, animations
        //by parameter names
        animLUT = new StatePersonAnimationLUT(transform);

        //we will need a conversation state

        //we will need a reponse state to said conversation

        //we will need an "gift" exchange state - after conversation some "thing" is exchanged
        //a map, some food, pretty much anything.

        //perhaps a fight state?

        //perhaps a love/hate state that does not result in fight right away?


        //rootState.childStates.Add();
    }
    private void Update()
    {
        int state = rootState.Process();
    }

}
