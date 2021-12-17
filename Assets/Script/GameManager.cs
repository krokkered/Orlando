using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] players;

    public AudioSource audioSource;
    public AudioClip loseSound;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameLost()
    {

        foreach (var player in players)
        {
            if (player.GetComponent<PlayerComponent>() != null)
                player.GetComponent<PlayerComponent>().setDead(); // makes players unable to move
            if (player.GetComponent<SinglePlayerComponent>() != null)
                player.GetComponent<SinglePlayerComponent>().setDead(); // makes players unable to move


        }

        GameObject.Find("HUD").transform.Find("Canvas").transform.Find("LoseScreen").gameObject.SetActive(true);
        audioSource.PlayOneShot(loseSound);

    }


    public void disablePlayers()
    {

        foreach (var player in players)
        {
            if (player.GetComponent<PlayerComponent>() != null)
                player.GetComponent<PlayerComponent>().disableMovement(); // makes players unable to move
            if (player.GetComponent<SinglePlayerComponent>() != null)
                player.GetComponent<SinglePlayerComponent>().disableMovement(); // makes players unable to move


        }
    }


    public void enablePlayers()
    {

        foreach (var player in players)
        {
            if (player.GetComponent<PlayerComponent>() != null)
                player.GetComponent<PlayerComponent>().enaableMovement(); // makes players unable to move
            if (player.GetComponent<SinglePlayerComponent>() != null)
                player.GetComponent<SinglePlayerComponent>().enableMovement(); // makes players unable to move


        }
    }

    public void removeObjectsWithTag(string tag)
    {

        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (var obj in objects)
        {
            Destroy(obj);
        }

    }

    public void enableCollisionOnTag(string tag)
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
        foreach (var obj in objects)
        {
            obj.GetComponent<Collider2D>().enabled = true;
        }

    }
}
