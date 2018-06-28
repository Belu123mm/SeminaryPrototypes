using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SerializeField]
public class AnimController : MonoBehaviour {
    public Animator character;
    [Header("Datos Binarios")]
    public bool walk;
    public bool jump;
    public bool run;
    public bool attack;
    public bool roll;
    public bool death;
    public bool getHit;
    public bool test;
    public float idleTimer;
    public bool combat;
    public Aim aim;
    public float xMov;
    public float yMov;
    public float zMov;
    public bool push;
    public int atackvalue;

    public void Start() {
        aim = GetComponent<Aim>();
        character = transform.GetChild(0).GetComponent<Animator>();
    }
    public void Update() {
        if ( Input.anyKey ) {
            idleTimer = 0;
            character.SetFloat("idleTimer", idleTimer);
        } else {
            idleTimer += Time.deltaTime;
            character.SetFloat("idleTimer", idleTimer);
        }
        combat = aim.aim;
        character.SetFloat("jumpValue", yMov); 
        character.SetBool("combat", combat);
        character.SetBool("walking", walk);
        if ( jump ) {

        character.SetTrigger("jump");
        }
        character.SetBool("run", run);
        character.SetBool("attack",attack);
        character.SetBool("roll", roll);
        character.SetBool("hit", getHit);
        character.SetBool("death",death);
        character.SetBool("push",push);
        character.SetInteger("attackValue", atackvalue);
        if (run)
        {
            
            character.SetFloat("movCombatHor", xMov);
        character.SetFloat("movCombatVer", zMov);
        }
        else
        {
            character.SetFloat("movCombatHor", xMov /2);
            character.SetFloat("movCombatVer", zMov /2);

        }


    }
    public void LateUpdate() {
        if ( getHit )
            getHit = false;
    }
}
