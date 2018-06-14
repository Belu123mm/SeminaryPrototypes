using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float distance;
    public Aim avatar;
    public bool added;
    // Use this for initialization
    void Start() {
        avatar = FindObjectOfType<Aim>();
    }
    public void Update() {
        float dist = Vector3.Distance(this.transform.position, avatar.transform.position);

        if (dist < distance && !added) {
            added = true;
           // avatar.AddEnemy(this);
        }else if (dist > distance && added ) {
            added = false;
           // avatar.RemoveEnemy(this);

        }
    }
}