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
    public Transform PersonTypes;

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
    /// <summary>
    /// Changes the type of the person.
    /// </summary>
    /// <param name="_type">The int type.</param>
    void changePersonType(int _type)
    {
        //given person type (random?) enable the model
        //first turn them all off
       
        foreach (Transform _person in PersonTypes)        
        {            
            _person.gameObject.SetActive(false);           
        }
        //enable the one, and buffer it should I need to know previous type (often the case)
        PersonTypes.GetChild(_type).gameObject.SetActive(true);
        curPersonType = typeOfPerson = _type;

    }





}
