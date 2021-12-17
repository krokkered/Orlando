using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caverna : MonoBehaviour
{

    public GameManager gm;
    // Start is called before the first fram update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void mostraCaverna()
    {
        GameObject.Find("HUD").transform.Find("Canvas").transform.Find("Caverna").gameObject.SetActive(true);
        gm.disablePlayers();
    }

    public void nascondiCaverna()
    {
        GameObject.Find("HUD").transform.Find("Canvas").transform.Find("Caverna").gameObject.SetActive(false);
        gm.enablePlayers();

    }


    private void OnTriggerEnter2D(Collider2D otherCol)
    {
        Rigidbody2D rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody != null && rbody.tag == "Player")
        {

            mostraCaverna();
        }
    }
}
