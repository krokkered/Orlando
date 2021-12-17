using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScore : MonoBehaviour
{
        ScoreManager scoreManager;
        public UnityEngine.UI.Text txt;
    // Start is called before the first frame update
    void Start()
    {
        scoreManager=GameObject.Find("ScoreManager").GetComponent<ScoreManager>();


     txt.GetComponent<UnityEngine.UI.Text>().text = scoreManager.getCurrentScore().ToString()+"/"+scoreManager.getTotalScore().ToString() ;


    }

    // Update is called once per frame
    void Update()
    {
     txt.GetComponent<UnityEngine.UI.Text>().text = scoreManager.getCurrentScore().ToString()+"/"+scoreManager.getTotalScore().ToString() ;

    }
}
