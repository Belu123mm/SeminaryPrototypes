﻿using System.Collections;
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
    public float idleTimer;
    public Aim aim;
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
        character.SetBool("walking", walk);
        character.SetBool("jump", jump);
        character.SetBool("run", run);
        character.SetBool("attack",attack);
        character.SetBool("roll", roll);
        character.SetBool("hit", getHit);
        character.SetBool("death",death);
        if ( run )
            character.speed = 1.5f;
        else
            character.speed = 1;

    }
    public void LateUpdate() {
        if ( getHit )
            getHit = false;
    }
}
