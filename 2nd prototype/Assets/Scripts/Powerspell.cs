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
    public bool trigger;
    public bool time;
        
	void Start () {
        transform.forward = avatar.forward;
        spellInterface.AvatarTransform(avatar);
        StartCollider();
        StartAnimations();
        spellInterface.StartSpell(this);
        spellView.StartVisual(this);
        StartCoroutine(EndAnimations(spellView.spellcd));
        Destroy(this.gameObject, spellView.spellcd);
    }
	
	// Update is called once per frame
	void Update () {
        if (!time)        timer += Time.deltaTime;


        //Corutine?
        if (timer > 0.2f)
        {
            trigger = true;
            time = true;
        }



        if (trigger == true)
        {
            print("hi");
            trigger = false;
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

    private void OnTriggerEnter(Collider collidingObject)
    {
        if (collidingObject.gameObject.layer == Layers.ENEMY)
        {
            if(spellInterface.ReturnSeasonID() == 2)
            collidingObject.gameObject.GetComponent<BearGeneric>().ApplyKnockback();

            if (spellInterface.ReturnSeasonID() == 3)
                collidingObject.gameObject.GetComponent<BearGeneric>().ApplyStun();
        }
    }
}
