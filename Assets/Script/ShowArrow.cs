using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowArrow : MonoBehaviour
{
    GameObject childArrow;

    // Start is called before the first frame update
    void Start()
    {
        childArrow=gameObject.transform.Find("freccia").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


        private void OnTriggerEnter2D(Collider2D otherCol)    {
            Rigidbody2D rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

            if (rbody!= null  && rbody.tag  == "Player"){
                if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled){
                childArrow.SetActive(true);
                }
                
            }
        }


             private void OnTriggerExit2D(Collider2D otherCol)   {
            if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled){
                childArrow.SetActive(false);
                }
             }

}
