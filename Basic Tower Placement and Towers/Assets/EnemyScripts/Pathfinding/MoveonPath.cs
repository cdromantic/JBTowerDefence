using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveonPath : MonoBehaviour {
    GameObject pathsHolder;
	Paths FollowthePreMadepath;

	public int CurrentwayPoint = 0;
	public float Speed = 1;
	public float ReachDistence = 0.25f;
	public float Rotationspeed = 0.5f;


	Vector3 Lastposition;
	Vector3 Currentposition;

	void Start () {
        pathsHolder = GameObject.FindGameObjectWithTag("WaveSpawner");
        FollowthePreMadepath = pathsHolder.GetComponent<Paths>();
        Lastposition = transform.position;
        
	}
	

	void Update () {
		float Distence = Vector3.Distance (FollowthePreMadepath.pathObject [CurrentwayPoint].position, transform.position);
		transform.position = Vector3.MoveTowards(transform.position,FollowthePreMadepath.pathObject [CurrentwayPoint].position, Time.deltaTime * Speed);


		if (Distence <= ReachDistence) {
			CurrentwayPoint++;
		}
			
	}
}
