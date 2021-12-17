using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.AI;


public class AutonomousBehaviour : MonoBehaviour
{

    public Camera cam;
    public GameObject otherPlayer;
    FindVisibleEnemies findenemies;

    PlayerComponent pl;
    NavMeshAgent agent;



    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        findenemies = cam.gameObject.GetComponent<FindVisibleEnemies>();
        pl = gameObject.GetComponent<PlayerComponent>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }


    public void DisableNavAgent()
    {
        agent.enabled = false;
    }
    public void EnableNavAgent()
    {
        agent.enabled = true;

    }



    void followplayer(GameObject playerToFollow)
    {
        Vector3 distanceFromOtherPlayer = otherPlayer.transform.position - transform.position;

        pl.setMovement(agent.velocity.x, agent.velocity.y);
        agent.SetDestination(playerToFollow.gameObject.transform.position);

        //stops if the other player is close
        if (Mathf.Pow(distanceFromOtherPlayer.x, 2) + Mathf.Pow(distanceFromOtherPlayer.y, 2) < 0.7f)
        {
            // agent.SetDestination(gameObject.transform.position);//stop moving
            Vector3 otherPlayerDirection = new Vector3(otherPlayer.GetComponent<PlayerComponent>().movement.x, otherPlayer.GetComponent<PlayerComponent>().movement.y, 0);
            agent.SetDestination(gameObject.transform.position + otherPlayerDirection * 3);
        }
    }

    public void autonomousMove()
    {

        if (findenemies.visibleUnwarnedEnemies.Count <= 1)
        {
            agent.stoppingDistance = 1.5f;
            followplayer(otherPlayer);


        }
        else
        {
            //the other charachter finds the second to the closest enemy and prepares to kill him
            GameObject enemytoReach = findEnemyToReach(); //il secondo nemico più vicino
            agent.stoppingDistance = 0;
            followplayer(enemytoReach);


            Vector3 distanceFromEnemy = enemytoReach.transform.position - transform.position;
            if (Mathf.Pow(distanceFromEnemy.x, 2) + Mathf.Pow(distanceFromEnemy.y, 2) < 0.4f)
            {
                // kill enemy! It kills the enemy only when player gives the order 
                //enemytoReach.GetComponent<StaticSoldier>().killed(); //uncomment this to make the otherplayer kill enemy autonomously
                agent.SetDestination(gameObject.transform.position); //stop moving

            }


        }
    }

    GameObject findEnemyToReach()
    {
        GameObject[] enemies = findenemies.visibleUnwarnedEnemies.ToArray();
        Array.Sort(enemies, delegate (GameObject a, GameObject b)
              {
                      // ordina i nemici in base alla distanza
                      return Vector3.Distance(a.transform.position, otherPlayer.transform.position).CompareTo(Vector3.Distance(b.transform.position, otherPlayer.transform.position));
              });

        return enemies[1];
    }


}
