using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class AutonomousBehaviour : MonoBehaviour
{

    public Camera cam;
    public GameObject otherPlayer;
    FindVisibleEnemies findenemies;

    PlayerComponent pl;

// for a*
public Transform target;
public float speed=400f;
public float nextWpDistance=3f;
int currentWp=0;
bool reached=false;

Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        findenemies = cam.gameObject.GetComponent<FindVisibleEnemies>();
        pl=gameObject.GetComponent<PlayerComponent>();
    
    rb=GetComponent<Rigidbody2D>();

    InvokeRepeating("UpdatePath",0f,0.5f);



    }   





		void Update () {
		}




void UpdatePath(){
}


void OnPathComplete(){



}

void reachPlayer(){

    		//	if (ai != null) ai.onSearchPath += Update;
/*
            if (path== null) return;

        if (currentWp >= path.vectorPath.Count){
            reached=true;
            return;
        } else{
            reached=false;
        }

        Vector2 direction=((Vector2) path.vectorPath[currentWp]- rb.position).normalized;

        Vector2 force=direction * speed *Time.deltaTime;

        rb.AddForce(force);
        Vector2 velocity = direction * speed ;

        float distance= Vector2.Distance(rb.position, path.vectorPath[currentWp]);


       // pl.movement  = Vector2.MoveTowards(rb.position,path.vectorPath[currentWp] , speed);
    

        if (distance< nextWpDistance){
            currentWp++;


        }*/
}
    // Update is called once per frame



void followplayer(){

/*
       Vector3 direction = otherPlayer.transform.position - transform.position;
       if (Mathf.Pow(direction.x, 2) + Mathf.Pow(direction.y, 2) <1.1){
           direction.x=otherPlayer.GetComponent<PlayerComponent>().movement.x;
           direction.y=otherPlayer.GetComponent<PlayerComponent>().movement.y;

       }
        pl.movement = direction;
*/

        reachPlayer();

}

public void autonomousMove(){ //the other charachter finds the second to the closest enemy and kills him
     

             followplayer();

    /*if (findenemies.visibleUnwarnedEnemies.Count <=1)
    else{

    GameObject[] enemies=findenemies.visibleUnwarnedEnemies.ToArray();
    Array.Sort(enemies,delegate (GameObject a, GameObject b) 
         {
             // ordina i nemici in base alla distanza
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
        pl.movement = direction;
    }*/
         }

}
