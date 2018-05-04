using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllThings : MonoBehaviour {
    public AnimController animC;
    public ISpell spells;
    public int life;
	// Use this for initialization
	void Start () {
        animC = GetComponent<AnimController>();
        spells = new SpringSpell(); //Asi seteo el default

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
        spells.Shoot();
    }
}
