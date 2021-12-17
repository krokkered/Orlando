using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepEnemyAwake : MonoBehaviour
{

    public List<GameObject> visibleEnemies;

    // Start is called before the first frame update
    void Start()
    {
        /*  enemies = GameObject.FindGameObjectsWithTag("Enemy");
          foreach (GameObject enemy in enemies)
          {
              if(cameraBox.OverlapPoint(enemy.transform.position) && enemy.GetComponent<StaticSoldier>().isAlive)
                  visibleEnemies.Add(enemy);
          }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<StaticSoldier>())
        {
            visibleEnemies.Add(other.gameObject);
            //print("lampada n "+ gameObject.transform.parent.gameObject.name+" soldato n "+ other.gameObject.name);
            setEnemyWarned(other.gameObject);
        }
    }


    private void setEnemyWarned(GameObject enemy)
    {
        enemy.GetComponent<StaticSoldier>().setWarned();

    }


    private void setEnemyUnwarned(GameObject enemy)
    {
        enemy.GetComponent<StaticSoldier>().setAlive();

    }

    public void UnwarnSoldiers()
    {
        foreach (GameObject enemy in visibleEnemies)
        {

            setEnemyUnwarned(enemy);
        }

    }
}
