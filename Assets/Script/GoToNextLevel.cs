using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GoToNextLevel : MonoBehaviour
{
    public string LevelName;
    ScoreManager scoreManager;


    // Start is called before the first frame update
    void Start()
    {
    scoreManager=GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GoToLevelOnCondition(scoreManager.TotalScoreReached());
    }


    public void GoToLevel()
    {
        SceneManager.LoadScene(LevelName);
    }

    public void GoToLevelOnCondition(bool condition)
    {
        if (condition)
            GoToLevel();
    }

}
