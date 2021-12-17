using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SinglePlayerComponent : MonoBehaviour
{

    public float moveSpeed = 2.3f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;
    bool isCrazy = false;
    bool isDead= false;
    public bool isBent{get; set;}= false;
    
    Vector2 movement;
    // Update is called once per frame


    void Start()
    {
    }

    void Update()
    {
        if (!isDead){
        if (!isCrazy)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }



        animate();
        }

    }


    void FixedUpdate()
    {

        if (!isBent  )
        if (!isDead)
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

    }



    void animate()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }


    public void goCrazy()
    {
        isCrazy = true;
    }



    public void setMovement(Vector2 newMov)
    {
        movement = newMov;
    }

    public Vector2 getMovement()
    {
        return movement;
    }

     public void increaseSpeed(float newSpeed)
     {
        moveSpeed+=newSpeed;
     }

     public void setDead(){

         isDead=true;
        animator.SetFloat("Speed", 0);

     }

    public void disableMovement(){

        isDead=true;
    }

    public void enableMovement(){

        isDead=false;
    }
}//endclass
