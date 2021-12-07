using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnawareFieldBehaviour : MonoBehaviour
{

    Soldier soldier;
    // Start is called before the first frame update
    void Start()
    {
        soldier=gameObject.GetComponentInParent<WalkingSoldier>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCol) {
    
        Rigidbody2D     rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody!= null  && rbody.tag  == "Player")
             {
            if (soldier.getAlive())
            {    
                soldier.setKillable();
                if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled)
                {
                    soldier.showSword();
                } 
            }
        }


        }

     private void OnTriggerExit2D(Collider2D otherCol)   {

        Rigidbody2D     rbody = otherCol.gameObject.GetComponent<Rigidbody2D>();

        if (rbody!= null  && rbody.tag  == "Player"){

            if (soldier.getKillable()){
                if (otherCol.gameObject.GetComponent<PlayerComponent>().isControlled){
                    soldier.hideSword();
                } 
                soldier.setAlive();
            }



        }
    } 


}

