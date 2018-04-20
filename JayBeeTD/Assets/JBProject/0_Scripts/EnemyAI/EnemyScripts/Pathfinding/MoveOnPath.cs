using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnPath : MonoBehaviour {
    [SerializeField]
    JayBeeHealth jBHP;
    GameObject pathsHolder;
    Paths followPath;
    EnemyWaveSpawn eWS;

    public int currentWayPoint = 0;
    public float speed = 1;
    public float reachDist = 0.25f;
    public float rotateSpeed = 0.5f;

    Vector3 lastPos;
    Vector3 currentPos;

    void Start() {
        pathsHolder = GameObject.FindGameObjectWithTag("WaveSpawner");
        eWS = pathsHolder.GetComponent<EnemyWaveSpawn>();
        followPath = pathsHolder.GetComponent<Paths>();
        lastPos = transform.position;
    }

    void Update() {
        if (currentWayPoint != followPath.pathObject.Count) {
            //this makes the enemy move towards the path
            Debug.Log(followPath.pathObject.Count);
            float dist = Vector3.Distance(followPath.pathObject[currentWayPoint].position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, followPath.pathObject[currentWayPoint].position, Time.deltaTime * speed);

            if (dist <= reachDist) {
                lastPos = followPath.pathObject[currentWayPoint].position;
                currentWayPoint++;
            }
        }

        else {
            jBHP.Damage();
            eWS.RemoveEnemyFromList(gameObject);
            Destroy(gameObject);
        }
    }
}
