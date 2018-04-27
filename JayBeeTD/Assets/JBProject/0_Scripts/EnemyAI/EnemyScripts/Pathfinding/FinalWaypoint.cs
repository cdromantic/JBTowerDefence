using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWaypoint : MonoBehaviour {
    GameObject jayBee;
    Transform jayBeeTF;
	// Use this for initialization
	void Start () {
        jayBee = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        jayBeeTF = jayBee.transform;
        transform.position = jayBeeTF.position;
	}
}
