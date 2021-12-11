using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
 
{
    public Vector2 pos;
    RectTransform rect;

    public GameObject buttonToHide;
   // public float transitionTime=5; // it doesn't work , should be fixed
    bool isHidden=false;
    void Start(){

        rect=gameObject.GetComponent<RectTransform>();
    }



    public void toggleHide(){

        if (isHidden){

               StartCoroutine(Move(rect, new Vector2(0f,0f)));
               //hide the other button if necessary

        }else{
               StartCoroutine(Move(rect, pos));

        }

        if(buttonToHide!=null){
                   buttonToHide.SetActive(!isHidden);
               }
        isHidden=!isHidden;


    }





     IEnumerator Move(RectTransform rt, Vector2 targetPos)
     {
         float step = 0;
         while (step < 1)
         {
             rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime);
             rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime);
             yield return new WaitForEndOfFrame();
         }
     }

}
