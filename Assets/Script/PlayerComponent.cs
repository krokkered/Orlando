using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerComponent : MonoBehaviour
{

public float moveSpeed =3f;
public Rigidbody2D rb;
public Animator animator;
public bool isControlled =false;
public Camera cam;
public GameObject otherPlayer;
FindVisibleEnemies findenemies;

Vector2 movement;
    // Update is called once per frame


    void Start(){

        if (!isControlled){
            moveSpeed =2.3f;
        }
        findenemies = cam.gameObject.GetComponent<FindVisibleEnemies>();
    }

    void Update()
    {

    if (Input.GetKeyUp("x")){
        ToggleControlled();
        animator.SetFloat("Speed",0); // to reset the animation

    }




    if (isControlled){

        movement.x=Input.GetAxisRaw("Horizontal");
        movement.y=Input.GetAxisRaw("Vertical");

        }

    else{

        autonomousBehaviour();

    }
    animate();

        }
void FixedUpdate() {

        rb.MovePosition(rb.position+movement*moveSpeed* Time.fixedDeltaTime);
    
}

void ToggleControlled(){

    if (!isControlled){
        moveSpeed =3f; 

        
        //must attach the camera to the controlled player
        FollowTarget cameraTarget = cam.GetComponent<FollowTarget>();
        cameraTarget.target = gameObject.transform;

        // little triangle to show the selected player
        GameObject triangleGizmo = gameObject.transform.Find("Triangle").gameObject;
        triangleGizmo.SetActive(true);
    }
    if (isControlled){
        moveSpeed =2.3f; // slower compared to the player

        // little triangle to show the selected player
        GameObject triangleGizmo = gameObject.transform.Find("Triangle").gameObject;
        triangleGizmo.SetActive(false);
    }
    isControlled=!isControlled;

}




void animate(){

        animator.SetFloat("Horizontal",movement.x);
        animator.SetFloat("Vertical",movement.y);
        animator.SetFloat("Speed",movement.sqrMagnitude);
}

void followplayer(){

       Vector3 direction = otherPlayer.transform.position - transform.position;
       if (Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2) <1.1){
           direction.x=otherPlayer.GetComponent<PlayerComponent>().movement.x;
           direction.y=otherPlayer.GetComponent<PlayerComponent>().movement.y;

       }
        movement = direction;

}

 void autonomousBehaviour(){ //the other charachter finds the second to the closest enemy and kills him
     
    if (findenemies.visibleUnwarnedEnemies.Count <=1)
        followplayer();
    else{

    GameObject[] enemies=findenemies.visibleUnwarnedEnemies.ToArray();
    Array.Sort(enemies,delegate (GameObject a, GameObject b) 
         {
             // ordina i nemidi in base alla distanza
           return Vector3.Distance(a.transform.position, otherPlayer.transform.position).CompareTo(Vector3.Distance(b.transform.position, otherPlayer.transform.position));
            });

    GameObject enemytoReach= enemies[1]; //il secondo nemico più vicino
    Vector3 direction = enemytoReach.transform.position - transform.position;
    if (Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2) <0.5){
           direction.x=0;
           direction.y=0;
           // kill enemy!
           enemytoReach.GetComponent<StaticSoldier>().killed();
       }

       Vector3 distanceFromOtherPlayer = otherPlayer.transform.position - transform.position;
       if (Mathf.Pow(distanceFromOtherPlayer.x, 2) + Mathf.Pow(distanceFromOtherPlayer.y, 2) <0.7){
           direction.x=0;
           direction.y=0;

       }
        movement = direction;
    }
         }


     
  void OnCollisionExit2D(Collision2D otherCol) {
                  //otherCol.rigidbody.isKinematic = false;
       Rigidbody2D rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody!= null  && rbody.tag  == "Player"){
            rbody.velocity=Vector3.zero;
        
    }

  

 }
}//endclass
