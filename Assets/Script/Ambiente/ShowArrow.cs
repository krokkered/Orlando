using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArrow : MonoBehaviour
{
    GameObject childArrow;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        childArrow = gameObject.transform.Find("freccia").gameObject;
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

    }

    void showArrow()
    {

        childArrow.SetActive(true);

    }

    void showArrowOnCondition(bool condition)
    {
        if (condition)
            childArrow.SetActive(true);

    }

    private void OnTriggerEnter2D(Collider2D otherCol)
    {
        Rigidbody2D rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody != null && rbody.tag == "Player")
        {
            if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled)
            {
                showArrowOnCondition(scoreManager.TotalScoreReached());
            }

        }
    }


    private void OnTriggerExit2D(Collider2D otherCol)
    {
        if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled)
        {
            childArrow.SetActive(false);
        }
    }

}
