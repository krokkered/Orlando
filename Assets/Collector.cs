using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private int CollectedItems=0 ; //mettere private

    // Start is called before the first frame update
    void Start()
    {
        CollectedItems=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addItem(){
        CollectedItems+=1;
    }
}
