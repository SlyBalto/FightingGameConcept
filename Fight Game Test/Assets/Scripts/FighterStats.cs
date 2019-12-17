using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStats : MonoBehaviour
{

    public CharacterController2D Controller;

    public int playerID = 1;

    public int health = 100;

    public float runSpeed = 40f;

    float P1MoveFloat = 0f;
    float P2MoveFloat = 0f;

    bool jump = false;

    public bool facingright = true;

    public GameObject attackexample;

    public Collider2D hurtbox;

    public Vector3 InstLocRight;

    public Vector3 InstLocLeft;





    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        InstLocRight = ((hurtbox.transform.position) + new Vector3(1f, 0.5f, 0));
        InstLocLeft = ((hurtbox.transform.position) + new Vector3(-1f, 0.5f, 0));

        if (playerID == 1)
        {
            P1MoveFloat = Input.GetAxisRaw("P1Move") * runSpeed;
        }
        else
            P2MoveFloat = Input.GetAxisRaw("P2Move") * runSpeed;
        // Debug.Log("P2MoveFloat = " + P2MoveFloat);
        //       ("WeaponNum = " + WeaponNum);

        if (playerID == 1)
        {
            if (Input.GetButtonDown("P1Jump"))
            {
                jump = true;
            }

            // This is the attack
            if (Input.GetButtonDown("P1Attack"))
            {
                if (facingright == true)
                {
                    GameObject ball;
                    ball = Instantiate(attackexample, InstLocRight, Quaternion.identity);
                    ball.transform.SetParent(hurtbox.transform);
                    //print("ball.gameObject.GetComponent<AttackScript>().AttackID == " + ball.gameObject.GetComponent<AttackScript>().AttackID);
                }
                else
                {
                    GameObject ball;
                    ball = Instantiate(attackexample, InstLocLeft, Quaternion.identity);
                    ball.transform.SetParent(hurtbox.transform);
                }
            
            }
        }


            //These are the same actions but they respond to player 2's controls if player ID = 2

            if (playerID == 2)
            {

           

                if (Input.GetButtonDown("P2Jump"))
                {
                        jump = true;
                }
            
            

              // This is the attack
              if (Input.GetButtonDown("P2Attack"))
              {
                if (facingright == true)
                {
                    GameObject ball;
                    ball = Instantiate(attackexample, InstLocRight, Quaternion.identity);
                    ball.transform.SetParent(hurtbox.transform);
                    ball.gameObject.GetComponent<AttackScript>().AttackID = playerID;
                }
                else
                {
                    GameObject ball;
                    ball = Instantiate(attackexample, InstLocLeft, Quaternion.identity);
                    ball.transform.SetParent(hurtbox.transform);
                    ball.gameObject.GetComponent<AttackScript>().AttackID = playerID;
                }
              }
            }

    }
   
        void OnTriggerEnter2D (Collider2D col)
        {

        // this tests if the incoming Attack Prefab has a different ID
        if (col.gameObject.GetComponent<AttackScript>().AttackID != playerID)
        {
            health = (health - 3);
            Debug.Log("ouch!" + health);
        }
    }
    
   

    //This is when the capsule and the AttackSphere are not
    //the same player ID and is a successful hit

     
    void FixedUpdate()
    { if (playerID == 1){ 
        Controller.Move(P1MoveFloat * Time.fixedDeltaTime, false, jump);
        jump = false;
        }
    else
        Controller.Move(P2MoveFloat * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}