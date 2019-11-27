using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FighterStats : MonoBehaviour
{

    public CharacterController2D controller;

    public int playerID = 1;

    public int health = 100;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    float inputHorz = 0f;

    bool jump = false;

    bool facingright = true;

    public GameObject attackexample;

    public Collider2D hurtbox;

   



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        // This is the attack
        //  if (Input.GetButtonDown("Fire1"))
        //  {
        //      Instantiate(attackexample, new Vector3(transform * 2.0F, 0, 0), Quaternion.identity);
        //   }

        //This is when the capsule and the AttackSphere are not
        //the same player ID and is a successful hit
        
    }
   // void OnTriggerEnter2D(Collider2D hurtbox)
    void OnTriggerEnter2D(Collider2D col)
    {
        // if (col == )
        health = (health - 20);
        Debug.Log("ouch!");
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}

