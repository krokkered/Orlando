using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nav : MonoBehaviour
{

    private GameObject Point;
PathManager pM;
public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        pM=gameObject.GetComponent<PathManager>();


    }

    // Update is called once per frame
    private void Update() {
        //pM.CalculatePath(target.position);

    }

}
