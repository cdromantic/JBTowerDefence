using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPathJB : MonoBehaviour {
    SpriteRenderer sPR;
    GameObject pathsHolder;
    Paths followPath;

    public int currentWayPoint = 0;
    public float speed = 1;
    public float reachDist = 0.25f;
    public float rotateSpeed = 0.5f;

    //Vector3 lastPos;
    Vector3 currentPos;

    void Start() {
        sPR = GetComponent<SpriteRenderer>();
        sPR.flipX = true;
        pathsHolder = GameObject.FindGameObjectWithTag("JBWaveSpawner");
        followPath = pathsHolder.GetComponent<Paths>();
        //lastPos = transform.position;
    }

    void Update() {
        if (currentWayPoint != followPath.pathObject.Count) {
            Debug.Log(followPath.pathObject.Count);
            float dist = Vector3.Distance(followPath.pathObject[currentWayPoint].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, followPath.pathObject[currentWayPoint].position, Time.deltaTime * speed);

            if (dist <= reachDist) {
                //lastPos = followPath.pathObject[currentWayPoint].position;
                currentWayPoint++;
                sPR.flipX = false;
            }
        }

        else {
            currentWayPoint = 0;
            sPR.flipX = true;
        }
    }
}