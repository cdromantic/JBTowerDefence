using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {
    [SerializeField]
    GameObject currentTarget;
    bool hasCurrentTarget = false;
    public float turretPower = 5f;
    public float turretRange = 10f;
    RaycastHit2D hit;

    float dist;

    public int reloadTime = 3;
    private float reloadTimef;
    float reloadTimer = 0;

    void Start() {
        reloadTimef = reloadTime * 1f;
    }
    void Update() {
        if (!hasCurrentTarget) {
            Debug.Log("We are finding a new target");
            GameObject tempTarget = null;
            RaycastHit2D[] hitMult;
            hitMult = Physics2D.CircleCastAll(transform.position, turretRange, Vector3.up, 0f);
            //Debug.Log(hitMult.Length);
            dist = turretRange + 1f;
            for (int i = 0; i < hitMult.Length; i++) {
                float tempDist = Vector2.SqrMagnitude(hitMult[i].collider.gameObject.transform.position - transform.position);
                if (tempDist < dist) {
                    dist = tempDist;
                    tempTarget = hitMult[i].collider.gameObject;
                }
            }
            if (tempTarget != null) {
                currentTarget = tempTarget;
                //SpriteRenderer sprTempDebug = currentTarget.GetComponent<SpriteRenderer>();
                //sprTempDebug.color = Color.red;
                hasCurrentTarget = true;
            }
        }
        else {
            if (currentTarget != null) {
                Vector3 dir = currentTarget.transform.position - transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            }
        }
        reloadTimer += Time.deltaTime;
        if (reloadTimer >= reloadTimef && hasCurrentTarget) {
            ShootCheck();
        }
        if (currentTarget == null) {
            hasCurrentTarget = false;
        }
    }

    void ShootCheck() {
        if (currentTarget != null) {
            if (!(Vector3.Magnitude(currentTarget.transform.position - transform.position) > turretRange)) {
                Shoot();
                reloadTimer = 0f;
            }
            else {
                //currentTarget.GetComponent<SpriteRenderer>().color = Color.white;
                currentTarget = null;
                hasCurrentTarget = false;
                Debug.Log("We have lost our old target");
            }
        }
    }

    void Shoot() {
        Debug.Log(gameObject.name + " has shot " + currentTarget.name);
        currentTarget.GetComponent<Enemyhealth>().Damage(turretPower);
    }
}
