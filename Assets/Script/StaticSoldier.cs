using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSoldier : Soldier
{


    private void OnTriggerEnter2D(Collider2D otherCol)    {

    Rigidbody2D     rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

    if (rbody!= null  && rbody.tag  == "Player"){

        if (soldierState==State.Alive || soldierState==State.Killable){

            
                soldierState=State.Killable;
                //if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled)
                {
                showSword();
                } 
        }

        if (soldierState==State.Warned){
            soldierState=State.WarnedClose;
        }


        }
    } 

   


     private void OnTriggerExit2D(Collider2D otherCol)   {

        Rigidbody2D     rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody!= null  && rbody.tag  == "Player"){

            if (soldierState==State.Killable){
                if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled){
                        hideSword();
                } 
                soldierState=State.Alive;
            }

                    if (soldierState==State.WarnedClose){
            soldierState=State.Warned;
        }


        }
    } 






}
