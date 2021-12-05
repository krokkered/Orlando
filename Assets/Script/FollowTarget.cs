using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowTarget : MonoBehaviour
{
    private Camera cam;
    private BoxCollider2D cameraBox;
    public BoxCollider2D boundary;
    public Transform target;

    private float leftPivot;
    private float rightPivot;
    private float topPivot;
    private float botPivot;

    void Start(){
        cam = gameObject.GetComponent<Camera>();
        cameraBox = cam.GetComponent<BoxCollider2D>();
    }
    void Update(){
        AspectRatioBoxChange();
        CalculateCameraPivot();
        FollowPlayer();
    }

    void AspectRatioBoxChange(){
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        cameraBox.size = new Vector2(width, height);
    }

    void CalculateCameraPivot(){
        botPivot = boundary.bounds.min.y + cameraBox.size.y/2;
        topPivot = boundary.bounds.max.y - cameraBox.size.y/2;
        leftPivot = boundary.bounds.min.x + cameraBox.size.x/2;
        rightPivot = boundary.bounds.max.x - cameraBox.size.x/2;

    }

    void FollowPlayer(){
        transform.position = new Vector3(Mathf.Clamp(target.position.x, leftPivot, rightPivot),
                                         Mathf.Clamp(target.position.y, botPivot, topPivot),
                                         transform.position.z);
    }

}
