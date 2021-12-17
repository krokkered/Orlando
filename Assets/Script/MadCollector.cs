using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadCollector : Collector
{
    Craziness craziness;
     void Start() {
        craziness= gameObject.GetComponent<Craziness>();
    }

     public override void  addItem(){
        base.addItem();
       print("incremento la pazzia");
        craziness.IncreaseCraziness();
    }
}