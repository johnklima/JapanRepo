using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Geisha          0
/// Ninja           1
/// Grunt           2
/// Warrior         3
/// Sensei          4
/// Village Man     5
/// Village Woman   6
/// </summary>
public class Person : Mammal
{

    public int typeOfPerson = 0;        //there are 7 types of person in japan world
    private int curPersonType = 0;      //something I will likely save to a json file
    private int persons = 7;

    // Start is called before the first frame update
    void Start()
    {
        
        changePersonType(typeOfPerson);

    }

    // Update is called once per frame
    void Update()
    {
        //should not a person be able to change?
        if(typeOfPerson != curPersonType)
        {
            changePersonType(typeOfPerson);
        }
    }

    void changePersonType(int _type)
    {
        //given person type (random?) enable the model
        //first turn them all off
        int p = 0;
        foreach (Transform _person in transform)
        {            
            if(p < persons)   //last transform is camera stick - TODO: change this
                _person.gameObject.SetActive(false);

            p++;
        }
        //enable the one, and buffer it should I need to know previous type (often the case)
        transform.GetChild(_type).gameObject.SetActive(true);
        curPersonType = typeOfPerson = _type;

    }





}
