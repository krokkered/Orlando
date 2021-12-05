using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindVisibleEnemies : MonoBehaviour
{

    //private BoxCollider2D cameraBox;
    private Camera cam;
    public GameObject[] enemies;
    public List<GameObject> visibleEnemies;
    public List<GameObject> visibleUnwarnedEnemies;

    public BoxCollider2D cameraBox;
    // Start is called before the first frame update
    void Start()
    {
    
        //cam = gameObject.GetComponent<Camera>();
        //cameraBox = cam.GetComponent<BoxCollider2D>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        visibleEnemies.Clear();
    foreach (GameObject enemy in enemies)
        {
            if(cameraBox.OverlapPoint(enemy.transform.position) && enemy.GetComponent<StaticSoldier>().isAlive)
                visibleEnemies.Add(enemy);
        }
   
         foreach (GameObject en in visibleEnemies){

         if(!en.GetComponent<StaticSoldier>().getWarned() )  // valido solo per i soldati fermi
            visibleUnwarnedEnemies.Add(en);
     }
      }
}
