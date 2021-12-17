using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwareFieldBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log("sei stato sgamato!");
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.GameLost();
    }
}
