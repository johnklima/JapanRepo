using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using player;

public class Player : MonoBehaviour
{
    public PlayerSheet playerSheet;

    private void Awake()
    {
        Random.InitState( (int)(Time.realtimeSinceStartup * 100.0f) );
    }

    // Start is called before the first frame update
    void Start()
    {
        playerSheet = new PlayerSheet(transform);
        if(playerSheet.load() == false)
        {
            Debug.Log("save new player sheet");
            playerSheet.save();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
