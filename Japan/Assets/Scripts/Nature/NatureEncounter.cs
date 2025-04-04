using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NatureEncounter : MonoBehaviour
{
    
    public List<Animal> animals;

    public int animalsNeeded = 2;
    private int currentlyHas = 0;  //animals

    private bool commence = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        if(commence)
        {
            foreach (Animal a in animals)
            {
                Debug.Log( a.GetType().ToString() );
                a.commence = true;
            }

            commence = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if ( other.transform.GetComponent<Animal>() )
        {
            Debug.Log("Nature trigger " + other.name);

            if(currentlyHas < animalsNeeded)
            {
                animals.Add(other.GetComponent<Animal>());
                currentlyHas++;
            }

            if (currentlyHas == animalsNeeded)
            {
                Debug.Log("do something with them ");

                Animal[] tanimls = animals.ToArray();
                
                foreach(Animal a in animals)
                {
                    for(int i = 0; i < tanimls.Length;i++)
                    {
                        if( a!= tanimls[i] && tanimls[i] != null)
                        {
                            a.others.Add(tanimls[i]);
                            
                            //look at the other
                            a.GetComponent<CharacterNavigator>().LookAtTarget = a.others[0].transform;

                            tanimls[i] = null;
                        }
                    }
                }

                commence = true;

            }
            
        }

    }
}
