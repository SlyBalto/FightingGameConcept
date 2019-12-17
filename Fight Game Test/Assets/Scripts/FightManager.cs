using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightManager : MonoBehaviour
{

    public GameObject Player1;
    public GameObject Player2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player1.transform.position.x < Player2.transform.position.x)
        {
            Debug.Log("Player 1 is on the left");
            Player1.gameObject.GetComponent<FighterStats>().facingright = true;
            Player2.gameObject.GetComponent<FighterStats>().facingright = false;

        }
        else
        {
            Player1.gameObject.GetComponent<FighterStats>().facingright = false;
            Player2.gameObject.GetComponent<FighterStats>().facingright = true;
        }
    }
}
