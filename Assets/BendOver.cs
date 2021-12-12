using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BendOver : MonoBehaviour
{
    
    SinglePlayerComponent pc;
     Animator anim;
     void Start()
     {
         anim = gameObject.GetComponent<Animator>();
         pc=gameObject.GetComponent<SinglePlayerComponent>();
     }
 
     void Update()
     {

             if (Input.GetKeyDown(KeyCode.LeftControl)){
                 anim.SetBool("IsBent",true);
                 pc.isBent=true;
                    }
            if (Input.GetKeyUp(KeyCode.LeftControl)){
                anim.SetBool("IsBent",false);
                pc.isBent=false;

                    }
         }
     
}
