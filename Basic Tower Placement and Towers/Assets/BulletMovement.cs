using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    float turretPower;
    Vector3 startPos;
    float moveDistance;
    public float bulletSpeed = 10;
    GameObject currentTarget;
    Vector3 targetVector;
    Vector3 targetVectorVector;

    void Update() {
        targetVectorVector = currentTarget.transform.position;
        transform.position += targetVectorVector.normalized*Time.deltaTime*bulletSpeed;
        if (Vector3.Distance(transform.position,startPos) >= moveDistance) {
            currentTarget.GetComponent<EnemyHealth>().Damage(turretPower);
            Destroy(gameObject);
        }
    }
    public void ParseTarget(GameObject target, float damage) {
        turretPower = damage;
        currentTarget = target;
        targetVector = currentTarget.transform.position;
        moveDistance = Vector3.Distance(transform.position, targetVector);
        startPos = transform.position;
    }
}
