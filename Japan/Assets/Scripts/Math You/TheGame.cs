using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheGame : MonoBehaviour
{
    public int MaxDays = 14;
    public int curDay = 0;

    public List<ADay> Days;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddDay(ADay _day)
    {
        
        if(Days.Count + 1 < MaxDays)
        {
            Days.Add(_day);
            curDay++;
        }
        else 
        {
            Debug.Log("Game Over");        
        }

    }
}
