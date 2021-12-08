using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    bool isPickable = false;
    public GameObject childSign;
    public Transform PlayerPosition;
    SpriteRenderer spriteRenderer;
    public Collector collector;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            if (isPickable)
            {
                this.pick();
            }
        }
        ChangeColourOnDistance();
    }



    void pick()
    {
        collector.addItem();
        Destroy(gameObject);
    }



    private void OnTriggerEnter2D(Collider2D otherCol)
    {

        isPickable = true;
        childSign.SetActive(true);

    }


    private void OnTriggerExit2D(Collider2D otherCol)
    {
        isPickable = false;
        childSign.SetActive(false);
    }


    void ChangeColourOnDistance()
    {
        Vector3 distanceFromPlayer = PlayerPosition.position - transform.position;
        float distanceValue = Mathf.Pow(distanceFromPlayer.x, 2) + Mathf.Pow(distanceFromPlayer.y, 2);
        distanceValue = Mathf.Clamp(1 - distanceValue / 3, 0.3f, 0.79f);
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, distanceValue);

    }
}
