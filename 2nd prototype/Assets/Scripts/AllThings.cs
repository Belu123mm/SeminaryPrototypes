using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllThings : MonoBehaviour {
    public AnimController animC;
    public int life;
	// Use this for initialization
	void Start () {
        animC = GetComponent<AnimController>();

    }

    // Update is called once per frame
    void Update () {
		if (life < 1 ) {
            animC.death = true;
        }
	}
    public void OnCollisionEnter( Collision collision ) {
        if ( collision.gameObject.GetComponent<Ball>() ) {
            life--;
        animC.getHit = true;

        }
    }
    public void Attack() {
        print("ATTACK >:C");
    }
}
