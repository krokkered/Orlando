using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSoldier : MonoBehaviour
{
    enum State
    {
        Alive,
        Killable,
        Dead,
        Warned,
        WarnedClose
    }

    
    public bool isAlive=true;
 
    private State soldierState=State.Alive;

    GameObject childSword;
    GameObject childBlood;
    // Start is called before the first frame update
    void Start()
    {
        childSword=gameObject.transform.Find("sword").gameObject;
        childBlood=gameObject.transform.Find("macchiadisangue").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
           
        if (Input.GetKeyUp( KeyCode.LeftControl)){

                if (soldierState == State.Killable){
                this.killed();

                }
                else if (soldierState == State.WarnedClose){
                    print("Oh no, hai svegliato il soldato!");
                    //partita persa, si riparte dal cicpoint
                }
        }

    
    }




    private void OnTriggerEnter2D(Collider2D otherCol)    {

    Rigidbody2D     rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

    if (rbody!= null  && rbody.tag  == "Player"){

        if (soldierState==State.Alive || soldierState==State.Killable){

            
                soldierState=State.Killable;
                if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled){
                childSword.SetActive(true);
                } 
        }

        if (soldierState==State.Warned){
            soldierState=State.WarnedClose;
        }


        }
    } 

    /*private void OnTriggerStay2D(Collider2D otherCol)
    {

    Rigidbody2D     rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

    if (rbody!= null  && rbody.tag  == "Player"){
        isKillable=true;
            if (!otherCol.gameObject.GetComponent<PlayerComponent>().isControlled && isAlive){
                //
                childSword.SetActive(false);
                }
            else if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled && isAlive){
               // isKillable=true;
                childSword.SetActive(true);
                }
        }
    }*/


     private void OnTriggerExit2D(Collider2D otherCol)   {

        Rigidbody2D     rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody!= null  && rbody.tag  == "Player"){

            if (soldierState==State.Killable){
                if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled){
                    childSword.SetActive(false);
                } 
                soldierState=State.Alive;
            }

                    if (soldierState==State.WarnedClose){
            soldierState=State.Warned;
        }


        }
    } 

    public void killed(){
        if (soldierState==State.Killable){

            soldierState=State.Dead;

            SpriteRenderer soldatoSprite = GetComponent<SpriteRenderer>();
            soldatoSprite.enabled = false;
            
            childSword.SetActive(false);
            childBlood.SetActive(true);

        }

    }

    public void setWarned(){

        soldierState=State.Warned;
    }

    public void setAlive(){
        print("io soldato mi riaddorment");
        soldierState=State.Alive;

    }

    public bool getWarned(){

        if (soldierState== State.Warned || soldierState== State.WarnedClose){
            return true;
        }
        return false;
    }

    public bool getAlive(){

        if (soldierState== State.Alive ){
            return true;
        }
        return false;
    }


}
