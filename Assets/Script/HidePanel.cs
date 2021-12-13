using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePanel : MonoBehaviour
 
{
    public Vector2 newPos;
    RectTransform rect;
    public GameObject buttonToHide;
   // public float transitionTime=5; // it doesn't work , should be fixed
    bool isHidden=false;
    Vector2 InitialPosition;
    public float duration=5f;

    void Start(){

        rect=gameObject.GetComponent<RectTransform>();
        InitialPosition=rect.anchoredPosition;


    }



    public void toggleHide(){

        if (isHidden){
          //  rect.anchoredPosition=InitialPosition;
            StopCoroutine("Move");
            StartCoroutine("Move", InitialPosition);
        }else{
        StopCoroutine("Move");
            StartCoroutine("Move", newPos);
           // rect.anchoredPosition=newPos;

        }
        
        //hide the other button if necessary
        if(buttonToHide!=null){
                   buttonToHide.SetActive(!isHidden);
               }
        isHidden=!isHidden;


    }





     IEnumerator Move( Vector2 pos)
     {
         float timeElapsed = 0;
         while (timeElapsed <= duration)
         {
            timeElapsed += Time.deltaTime;
             //rt.offsetMin = Vector2.Lerp(rt.offsetMin, targetPos, step += Time.deltaTime);
            // rt.offsetMax = Vector2.Lerp(rt.offsetMax, targetPos, step += Time.deltaTime);
         
         //   float x=Mathf.Lerp(rt.anchoredPosition.x,offset.x, step += Time.deltaTime);
          //  float y=Mathf.Lerp(rt.anchoredPosition.y,offset.y, step += Time.deltaTime);

            rect.anchoredPosition=Vector2.Lerp(rect.anchoredPosition,pos,timeElapsed/duration);
             yield return null;
         }
         //rt.anchoredPosition=pos;
     }



    
}
