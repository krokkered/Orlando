using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerComponent : MonoBehaviour
{

    public float moveSpeed = 3f;
    Rigidbody2D rb;
    public Animator animator;
    public bool isControlled = false;
    bool isDead = false;
    public Camera cam;
    public GameObject otherPlayer;
    FindVisibleEnemies findenemies;
    AutonomousBehaviour ab;
    public Vector2 movement;
    // Update is called once per frame


    void Start()
    {

        if (!isControlled)
        {
            moveSpeed = 2.3f;
        }
        findenemies = cam.gameObject.GetComponent<FindVisibleEnemies>();
        ab = gameObject.GetComponent<AutonomousBehaviour>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {


        if (Input.GetKeyUp("x"))
        {
            ToggleControlled();
            animator.SetFloat("Speed", 0); // to reset the animation

        }

        if (!isDead)
        {
            if (isControlled)
            {

                movement.x = Input.GetAxisRaw("Horizontal");
                movement.y = Input.GetAxisRaw("Vertical");

            }

            animate();
        }
    }
    void FixedUpdate()
    {
        if (!isDead)
        {
            if (isControlled)
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

            else
            {
                ab.autonomousMove();

            }
        }
    }

    void ToggleControlled()
    {

        if (!isControlled)
        {
            moveSpeed = 3f;


            //must attach the camera to the controlled player
            FollowTarget cameraTarget = cam.GetComponent<FollowTarget>();
            cameraTarget.target = gameObject.transform;

            // little triangle to show the selected player
            GameObject triangleGizmo = gameObject.transform.Find("Triangle").gameObject;
            triangleGizmo.SetActive(true);

            ab.DisableNavAgent();
        }
        if (isControlled)
        {
            moveSpeed = 2.3f; // slower compared to the player

            // little triangle to show the selected player
            GameObject triangleGizmo = gameObject.transform.Find("Triangle").gameObject;
            triangleGizmo.SetActive(false);
            ab.EnableNavAgent();
        }
        isControlled = !isControlled;

    }




    void animate()
    {




        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }







    void OnCollisionExit2D(Collision2D otherCol)
    {
        //otherCol.rigidbody.isKinematic = false;
        Rigidbody2D rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody != null && rbody.tag == "Player")
        {
            rbody.velocity = Vector3.zero;

        }
    }


    public void setMovement(float x, float y)
    {
        movement.x = x;
        movement.y = y;
    }

    public void setDead()
    {
        isDead = true;
        animator.SetFloat("Speed", 0);
        ab.DisableNavAgent();
    }
}//endclass
