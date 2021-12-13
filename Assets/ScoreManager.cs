using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{   
    [SerializeField]
     private int TotalScore;
    //public int CurrentScore{ get; private set ;}=0;
    [SerializeField]
     private int CurrentScore=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void IncreaseScore(){
        CurrentScore+=1;
    }


    public bool TotalScoreReached(){

        return CurrentScore== TotalScore;
    }

    public int getTotalScore(){
        return TotalScore;
    }

    public int getCurrentScore(){
        return CurrentScore;
    }
}
