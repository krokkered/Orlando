using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallenINWater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D otherCol)
    {

        Rigidbody2D rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody != null)
        {
            if (rbody.tag == "Player")
            {

                Debug.Log("sei caduto nell'acqua!");
                GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

                gameManager.GameLost();
            }
        }
    }
}
