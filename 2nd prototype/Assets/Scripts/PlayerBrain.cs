using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public ParticleController pCont;
    public Aim aimComp;
    public bool death;
    public bool combat;
    /*
    //  GASTON IN

    public float powerCooldown;
    private float _timePowers;
    public float movementCooldown;
    private float _timeMovement;

    //  GASTON OUT

    */
    public void Awake() {
        mvComp = GetComponent<Movement>();
        powComp = GetComponent<Powers>();
        animC = GetComponent<AnimController>();
        aimComp = GetComponent<Aim>();
        cam = FindObjectOfType<Camera>();
        pCont = GetComponent<ParticleController>();
    }
    public void FixedUpdate() { //Input Actions
        if ( !death && !mvComp.hit ) {
            if ( !powComp.shoot && !mvComp.rolling ) {
                xInput = Input.GetAxis("Horizontal");
                zInput = Input.GetAxis("Vertical");


                if ( Input.GetButton("Horizontal") || Input.GetButton("Vertical") ) {

                    if ( mvComp.running ) {
                        Vector3 forw = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
                        Vector3 rght = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);
                        if ( combat ) {
                            mvComp.RunningOnCombat(forw * zInput + rght * xInput);

                        } else {
                            mvComp.Running(forw * zInput + rght * xInput);
                        }
                        this.GetComponent<Rigidbody>().freezeRotation = true;
                        animC.run = true;
                        animC.walk = false;

                    } else {
                        Vector3 forw = new Vector3((this.transform.position - cam.transform.position).normalized.x, 0, (this.transform.position - cam.transform.position).normalized.z);
                        Vector3 rght = Vector3.Cross(this.transform.up, (this.transform.position - cam.transform.position).normalized);
                        if ( combat ) {
                            mvComp.MoveOnCombat(forw * zInput + rght * xInput);
                        } else {
                            mvComp.Move(forw * zInput + rght * xInput);
                        }
                        animC.walk = true;
                        animC.run = false;
                    }

                }
                else {

                    animC.run = false;
                    animC.walk = false;

                }
                if ( combat ) {
                    animC.xMov = xInput;
                    animC.zMov = zInput;
                }


                //Jump
                if ( Input.GetButton("Jump") && !mvComp.spammingSpace && !mvComp.rolling && !powComp.shoot )//&& Time.time > _timeMovement + movementCooldown)
                {
                    if ( mvComp.jumpValue < mvComp.currentStamina ) {
                        //_timeMovement = Time.time;
                        mvComp.Jump();
                        pCont.JumpSmoke();
                        animC.jump = true;
                    }
                } else {
                    animC.jump = false;
                }
                //Roll
                if ( Input.GetButton("Fire1") && !mvComp.rolling && mvComp.ground && !powComp.shoot )//&& Time.time > _timeMovement + movementCooldown) 
                    {
                    if ( mvComp.rollValue < mvComp.currentStamina ) {
                        //_timeMovement = Time.time;
                        mvComp.timer = 0;
                        mvComp.rolling = true;
                        animC.roll = true;
                        xInput = Input.GetAxis("Horizontal");
                        Vector3 forw = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);

                        zInput = Input.GetAxis("Vertical");
                        Vector3 rght = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);
                        mvComp.SideRoll(forw * zInput + rght * xInput);
                        this.GetComponent<Rigidbody>().freezeRotation = true;
                    }
                } else {
                    animC.roll = false;
                }
                //TestPush
                if ( Input.GetKeyDown(KeyCode.H) )
                {
                    
                }

            } else
                this.GetComponent<Rigidbody>().freezeRotation = true;

        }
    }
    public void Update() {  //Triggered actions 
        combat = aimComp.aim;
        death = animC.death;
        animC.yMov = mvComp.Rigidbody.velocity.y;
        mvComp.running = false;
        animC.push = false;
        animC.getHit = false;
        animC.roll = false;

        if (death && Input.GetKeyDown(KeyCode.R) ) {

        }

        if ( Input.GetKeyDown(KeyCode.J) ) {
            pCont.HitSparks();
            mvComp.hit = true;
            animC.getHit = true;
            mvComp.delayHit = 0.5f;
        }

        if ( mvComp.hit ) {
            mvComp.delayHit -= Time.deltaTime;
        }
        if ( mvComp.delayHit < 0 ) {
            mvComp.hit = false;
            //mvComp.StopSpeed();
        }

            if ( Input.GetButton("Fire3") )
                mvComp.running = true;
            else
                mvComp.running = false;

        if ( !death && !mvComp.hit ) {
            //Attack
            if ( Input.GetButtonDown("Fire2") && !powComp.shoot && !mvComp.spammingSpace && !mvComp.rolling ) //&& Time.time > _timePowers + powerCooldown && Time.time > _timeMovement + movementCooldown)
            {
                //_timePowers = Time.time;
                //_timeMovement = Time.time;

                powComp.timer = 0;

                powComp.Shoot();
                animC.walk = false;
                animC.run = false;
                powComp.shoot = true;
                animC.attack = true;
            } else {
                animC.attack = false;
            }
            //Target
            if ( Input.GetButtonDown("Click") ) {
                aimComp.Targeted();
            }
            //SetPowers
            if ( Input.GetButton("one") ) {
                powComp.SetPowerType("shield");
                animC.atackvalue = 0;
            }
            if ( Input.GetButton("two") ) {
                powComp.SetPowerType("rock");
                animC.atackvalue = 1;

            }
            if ( Input.GetButton("three") ) {
                powComp.SetPowerType("wind");
                animC.atackvalue = 2;

            }
            if ( Input.GetButton("four") ) {
                powComp.SetPowerType("plant");
                animC.atackvalue = 3;

            }

        }
    }

    public IEnumerator Reload() {
        SceneManager.LoadScene(0);
        yield return new WaitForSeconds(7);

    }
}
