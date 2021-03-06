using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingSoldier : Soldier
{

    public Animator animator;
    public Vector2 movement;
    public Transform StartingPoint;
    public Transform EndingPoint;
    private Transform pointToReach;
    public float moveSpeed = 1;

    private GameObject AwareField;
    private GameObject UnawareField;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        transform.position = StartingPoint.transform.position;
        pointToReach = EndingPoint;
        AwareField = gameObject.transform.Find("AwareField").gameObject;
        UnawareField = gameObject.transform.Find("UnawareField").gameObject;

        soldierState = State.Alive;
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        if (soldierState != State.Dead)
        {
            Move();
            animate();

            placeFields(AwareField);  // to look for the player in the fiel osition 
            placeFields(UnawareField);
        }

    }


    void animate()
    {

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void Move()
    {
        // If Enemy didn't reach last waypoint it can move
        // If enemy reached last waypoint then it stops


        // Move Enemy from current waypoint to the next one
        // using MoveTowards method
        transform.position = Vector2.MoveTowards(transform.position,
           pointToReach.transform.position,
           moveSpeed * Time.deltaTime);

        // If Enemy reaches position of waypoint he walked towards
        // then waypointIndex is increased by 1
        // and Enemy starts to walk to the next waypoint
        if (transform.position == EndingPoint.transform.position)
        {
            pointToReach = StartingPoint;
        }
        else if (transform.position == StartingPoint.transform.position)
        {
            pointToReach = EndingPoint;
        }

        movement = pointToReach.transform.position - transform.position;
    }



    void placeFields(GameObject field)
    {
        float fixeddistance = 0.7f;
        field.transform.localPosition = new Vector3(fixeddistance * Mathf.Sign(movement.x), fixeddistance * Mathf.Sign(movement.y), field.transform.position.z);
        float rotationAmount = 0;

        if (Mathf.Sign(movement.x) == 1 && Mathf.Sign(movement.y) == 1)
        {
            rotationAmount = 135;
        }

        //diagonal positions
        else if (Mathf.Sign(movement.x) == 1 && Mathf.Sign(movement.y) == -1)
        {
            rotationAmount = 45;
        }
        else if (Mathf.Sign(movement.x) == 1 && Mathf.Sign(movement.y) == -1)
        {
            rotationAmount = 135;
        }
        else if (Mathf.Sign(movement.x) == -1 && Mathf.Sign(movement.y) == -1)
        {
            rotationAmount = -45;
        }
        else if (Mathf.Sign(movement.x) == -1 && Mathf.Sign(movement.y) == 1)
        {
            rotationAmount = -135;
        }
        //TODO add cases when movement.x ==0 and y positive, for horizontal and vertical positions
        field.transform.eulerAngles = new Vector3(0, 0, rotationAmount);
    }


    public override void killed()
    {
        base.killed();
        print("ucciso soldato camminante");
        //UnawareField.SetActive(false);
        AwareField.SetActive(false);

        Destroy(AwareField);
    }
}
