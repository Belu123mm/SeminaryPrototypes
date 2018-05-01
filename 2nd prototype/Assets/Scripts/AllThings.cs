using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllThings : MonoBehaviour {

    public int life;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (life < 1 ) {
            print("dyed D:");
        }
	}
    public void OnCollisionEnter( Collision collision ) {
        if ( collision.gameObject.GetComponent<Ball>() )
            life--;
    }
    public void Attack() {
        print("ATTACK >:C");
    }
}
