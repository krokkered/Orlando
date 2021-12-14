using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject[] players;
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

        print("caduta del gamelost");
        GameObject.Find("HUD").transform.Find("Canvas").transform.Find("LoseScreen").gameObject.SetActive(true);
    }
}
