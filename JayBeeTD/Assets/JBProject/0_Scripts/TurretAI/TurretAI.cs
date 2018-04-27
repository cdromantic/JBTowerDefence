using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour {
    AudioSource myAudioSource;
    [SerializeField]
    GameObject currentTarget;
    public Sprite bulletSprite;
    bool hasCurrentTarget = false;
    public float turretPower;
    public float turretRange;
    RaycastHit2D hit;

    float dist;

    public float reloadTime = 3;
    private float reloadTimef;
    float reloadTimer = 0;

    void Start() {
        myAudioSource = GetComponent<AudioSource>();
        reloadTimef = reloadTime * 1f;
    }
    void Update() {
        if (!hasCurrentTarget) {
            Debug.Log("We are finding a new target");
            GameObject tempTarget = null;
            Collider2D[] hitMult;
            hitMult = Physics2D.OverlapCircleAll(transform.position, turretRange);
            //Debug.Log(hitMult.Length);
            dist = turretRange + 1f;
            for (int i = 0; i < hitMult.Length; i++) {
                float tempDist = Vector2.Distance(hitMult[i].gameObject.transform.position, transform.position);
                if (tempDist < dist) {
                    dist = tempDist;
                    tempTarget = hitMult[i].gameObject;
                }
            }
            if (tempTarget != null) {
                currentTarget = tempTarget;
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
            if (Vector3.Distance(currentTarget.transform.position, transform.position) <= turretRange) {
                Debug.Log("We shot with " + Vector3.Distance(currentTarget.transform.position, transform.position) + " distance");
                Shoot();
                reloadTimer = 0f;
            }
            else {
                Debug.Log("test");
                hasCurrentTarget = false;
                Debug.Log("We have lost our old target");
                currentTarget = null;
            }
        }
    }

    void Shoot() {
        myAudioSource.Play();
        Debug.Log(gameObject.name + " has shot " + currentTarget.name);
        GameObject bullet = new GameObject("bullet");
        bullet.transform.rotation = transform.rotation;
        SpriteRenderer bulletSPR = bullet.AddComponent<SpriteRenderer>();
        bulletSPR.sprite = bulletSprite;
        bullet.transform.position = transform.position;
        BulletMovement bulletScript = bullet.AddComponent<BulletMovement>();
        bulletScript.ParseTarget(currentTarget, turretPower, this);
    }
}