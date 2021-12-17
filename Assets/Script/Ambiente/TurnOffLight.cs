using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffLight : MonoBehaviour
{

    GameObject childSmoke;
    private bool isOn = true;
    private bool isExtinguishable = false;

    // Start is called before the first frame update
    void Start()
    {
        childSmoke = gameObject.transform.Find("fumo").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
            this.turnOff();
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCol)
    {

        Rigidbody2D rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody != null && rbody.tag == "Player")
        {

            if (isOn)
            {
                if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled)
                {
                    childSmoke.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D otherCol)
    {

        Rigidbody2D rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody != null && rbody.tag == "Player")
        {
            isExtinguishable = true;
            if (!otherCol.gameObject.GetComponent<PlayerComponent>().isControlled && isOn)
            {
                //
                //childSmoke.SetActive(false);
            }
            if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled && isOn)
            {
                childSmoke.SetActive(true);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D otherCol)
    {

        Rigidbody2D rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody != null && rbody.tag == "Player")
        {

            if (isOn)
            {
                isExtinguishable = false;
                childSmoke.SetActive(false);
            }
        }
    }
    public void turnOff()
    {
        if (isExtinguishable)
        {

            isOn = false;

            gameObject.transform.Find("alone").gameObject.GetComponent<KeepEnemyAwake>().UnwarnSoldiers();

            childSmoke.SetActive(false);
            gameObject.SetActive(false);

        }

    }
}
