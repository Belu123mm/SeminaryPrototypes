using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour { 
    //Aca se colocan los inputs y se llama a movement (mvcomp) y se ejecutan esas cosas. 
    [Header("Entradas")]
    public float xInput;
    public float zInput;
    public float mouseX;
    public float mouseY;
    [Header("Componentes")]
    public Movement mvComp;
    public Camera cam;
    //public CameraControl currentCam;
    public Powers powComp;
    public AnimController animC;
    public bool isCombat;
    public Aim aimComp;
    public bool death;
    public bool combat;
    public void Awake() {
        mvComp = GetComponent<Movement>();
        powComp = GetComponent<Powers>();
        animC = GetComponent<AnimController>();
        aimComp = GetComponent<Aim>();
        cam = FindObjectOfType<Camera>();
    }
    public void FixedUpdate() { //Input Actions
        if ( !death ) {
            if ( !powComp.shoot && !mvComp.rolling ) {
                print("xd");
                if ( Input.GetButton("Horizontal") || Input.GetButton("Vertical") && !mvComp.running ) {
                    xInput = Input.GetAxis("Horizontal");
                    Vector3 forw = new Vector3((this.transform.position - cam.transform.position).normalized.x, 0, (this.transform.position - cam.transform.position).normalized.z);
                    zInput = Input.GetAxis("Vertical");
                    Vector3 rght = Vector3.Cross(this.transform.up, (this.transform.position - cam.transform.position).normalized);
                    if ( combat ) {
                        mvComp.MoveOnCombat(forw * zInput + rght * xInput);
                        animC.xMov = xInput;
                        animC.zMov = zInput;

                    } else {
                        mvComp.Move(forw * zInput + rght * xInput);
                    }
                    animC.walk = true;
                } else animC.walk = false;
                if ( Input.GetButton("Fire3") ) {
                    mvComp.running = true;
                    if ( mvComp.runValue < mvComp.currentStamina ) {

                        xInput = Input.GetAxis("Horizontal");
                        Vector3 forw = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);

                        zInput = Input.GetAxis("Vertical");
                        Vector3 rght = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);

                        mvComp.Running(forw * zInput + rght * xInput);
                        animC.run = true;
                    } else
                        animC.run = false;

                } else
                    animC.run = false;

            }
        }
    }
    public void Update() {  //Triggered actions 
        combat = aimComp.aim;
        death = animC.death;
        animC.yMov = mvComp.Rigidbody.velocity.y;
        mvComp.running = false;

        if ( !death ) {
            //Attack
            if ( Input.GetButtonDown("Fire2") && !powComp.shoot) {
                powComp.timer = 0;

                powComp.Shoot();
                powComp.shoot = true;
                animC.attack = true;
            } else {
                animC.attack = false;
            }
            //Target
            if ( Input.GetButtonDown("Click") ) {
                aimComp.Targeted();
            }
            //Jump
            if ( Input.GetButton("Jump") && !mvComp.spammingSpace ) {
                if ( mvComp.jumpValue < mvComp.currentStamina) {

                mvComp.Jump();
                animC.jump = true;
                }
            } else {
                animC.jump = false;
            }
            //Roll
            if ( Input.GetButton("Fire1") && !mvComp.rolling && mvComp.ground) {
                if ( mvComp.rollValue < mvComp.currentStamina ) {
                    mvComp.timer = 0;
                    mvComp.rolling = true;
                    animC.roll = true;
                    mvComp.Roll();
                }
            } else  {
                animC.roll = false;
            }
            //TestPush
            if ( Input.GetKey(KeyCode.H) ) {
                mvComp.Push();
                animC.push = true;

            } else {
                animC.push = false;

            }
            //SetPowers
            if ( Input.GetButton("one") ) {
                powComp.SetPowerType("spring");
                animC.atackvalue = 0;
            }
            if ( Input.GetButton("two") ) {
                powComp.SetPowerType("summer");
                animC.atackvalue = 1;

            }
            if ( Input.GetButton("three") ) {
                powComp.SetPowerType("fall");
                animC.atackvalue = 2;

            }
            if ( Input.GetButton("four") ) {
                powComp.SetPowerType("winter");
                animC.atackvalue = 3;

            }

            //AnimationTest
            if ( Input.GetKeyDown(KeyCode.T) ) {
                if ( animC.test == true ) {
                    animC.test = false;

                } else
                if ( animC.test == false ) {
                    animC.test = true;

                }
            }
        }
    }
}
