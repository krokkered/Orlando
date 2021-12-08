using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craziness : MonoBehaviour
{
    public SinglePlayerComponent playerRef;


    protected int CrazinessStage=0;

    /*
    
    -1 invertire su e giù + piccolo aumento velocità
    -2 invertire dx e sx + piccolo aumento velocità
    -3  aumento velocità
    
    */
    float axisx=0;
    float axisy=0;
    // Start is called before the first frame update
    void Start()
    {
        playerRef.goCrazy();
        //playerRef.setMovement(new Vector2(1f,0f) );
    }

    // Update is called once per frame
    void Update()
    {

        //horizontal and vertical continuous movement
        if (Input.GetKey(KeyCode.UpArrow)){
            axisx=0;
            axisy=1f;
        }

        else if (Input.GetKey(KeyCode.DownArrow)){
            axisx=0;
            axisy=-1f;
        }

        else if (Input.GetKey(KeyCode.LeftArrow)){
            axisx=-1f;
            axisy=0;

        }

        else if (Input.GetKey(KeyCode.RightArrow)){
            axisx=1f;
            axisy=0;

        }
    //diagonal continuous movement
        if (Input.GetKey(KeyCode.UpArrow ) && Input.GetKey(KeyCode.LeftArrow) ){
            axisx=-1f;
            axisy=1f;
        }

        if (Input.GetKey(KeyCode.UpArrow ) && Input.GetKey(KeyCode.RightArrow) ){
            axisx=1f;
            axisy=1f;
        }

        if (Input.GetKey(KeyCode.DownArrow ) && Input.GetKey(KeyCode.LeftArrow) ){
            axisx=-1f;
            axisy=-1f;

        }

        if (Input.GetKey(KeyCode.DownArrow ) && Input.GetKey(KeyCode.RightArrow) ){
            axisx=1f;
            axisy=-1f;

        }

        crazyMove();
     }

     private void OnCollisionEnter2D(Collision2D other) {
         print("collido");
        axisx=-axisx;
        axisy=-axisy;
     }

     public void IncreaseCraziness(){
         CrazinessStage+=1;
         print("incremento la pazzia " + CrazinessStage);
         switch (CrazinessStage){

            case 1:
                playerRef.increaseSpeed(0.5f);
                break;
            case 2:
                playerRef.increaseSpeed(0.5f);
                break;
            case 3:
                playerRef.increaseSpeed(1.5f);
                break;
         }
     }

     private void crazyMove(){

         switch (CrazinessStage){

             case 0:
                playerRef.setMovement(new Vector2(axisx,axisy) );
                break;
            case 1:
                playerRef.setMovement(new Vector2(axisx,-axisy) );
                break;
            case 2:
                playerRef.setMovement(new Vector2(-axisx,-axisy) );
                break;
            case 3:
                playerRef.setMovement(new Vector2(-axisx,-axisy) );
                break;
         }

     }

}
