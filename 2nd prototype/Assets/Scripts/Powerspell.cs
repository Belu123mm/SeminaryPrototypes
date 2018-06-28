using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Powerspell : MonoBehaviour {
    public ISpell spellInterface;
    public vSpell spellView;
    public Transform avatar;
    public Animator animCollider;
    public Animator animMesh;
    public float timer;
    bool trigger;
        
	void Start () {
        transform.forward = avatar.forward;
        spellInterface.AvatarTransform(avatar);
        StartCollider();
        StartAnimations();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (timer < 5)
        timer += Time.deltaTime;

        print(spellView.triggered);
        if (timer > 0.4f && trigger == false)
        {
            spellInterface.StartSpell(this);
            spellView.StartVisual(this);
            StartCoroutine(EndAnimations(spellView.spellcd));
            Destroy(this.gameObject, spellView.spellcd);
            trigger = true;
        }

        spellInterface.SpellUpdate(this.gameObject);


    }
    void StartCollider() {
        animCollider = transform.GetChild(0).GetComponent<Animator>();      //El collider siempre es el 0
    }
     void StartAnimations() {
        animCollider.SetInteger("spellid", spellView.spellID);
        if ( animMesh ) {
        animMesh.SetBool("start", true);
        }
    }
    public IEnumerator EndAnimations( float time ) {
        print("finishing");
        yield return new WaitForSeconds(time - 2);
        animCollider.SetBool("end", true);


    }

    private void OnCollisionEnter( Collision collision ) {
        //Aca ps pones lo que falta 
    }
}
