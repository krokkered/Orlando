using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SinglePlayerComponent : MonoBehaviour
{

public float moveSpeed =3f;
public Rigidbody2D rb;
public Animator animator;
public Camera cam;

Vector2 movement;
    // Update is called once per frame


    void Start(){

            moveSpeed =2.3f;
        
    }

    void Update()
    {




        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");

        animate();




        }
void FixedUpdate() {


        rb.MovePosition(rb.position+movement*moveSpeed* Time.fixedDeltaTime);

}



void animate(){

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
}



     
  


}//endclass
