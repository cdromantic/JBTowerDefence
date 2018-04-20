using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {
    Vector3 oldVector;
    TurretAI turretReference;
    float travelTime;
    float turretPower;
    public float bulletSpeed = 10;
    GameObject currentTarget;
    Vector3 targetVector;

    void Update() {
        travelTime += Time.deltaTime;
        if (currentTarget != null) MoveMethod();
        DamageCheck();
    }

    private void DamageCheck() {
        DeathCheck();
        if (currentTarget != null) {
            if (Vector3.Distance(currentTarget.transform.position, transform.position) <= 0.25f) {
                currentTarget.GetComponent<EnemyHealth>().Damage(turretPower);
                Destroy(gameObject);
            }
            DeathCheck();
        }
    }

    private void MoveMethod() {
        targetVector = Vector3.Normalize(currentTarget.transform.position - transform.position);
        transform.position += targetVector * Time.deltaTime * bulletSpeed;
        oldVector = targetVector;
    }

    private void DeathCheck() {
        if (currentTarget != null) {
            //nothing
        }
        else {
            transform.position += targetVector * Time.deltaTime * bulletSpeed;
            if (travelTime >= 10f) Destroy(gameObject);
        }
    }

    public void ParseTarget(GameObject target, float damage, TurretAI turret) {
        turretPower = damage;
        currentTarget = target;
        turretReference = turret;
    }
}