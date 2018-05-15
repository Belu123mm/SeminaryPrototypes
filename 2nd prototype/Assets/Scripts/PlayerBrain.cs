using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour, IObserver {
    //Aca se colocan los inputs y se llama a movement (mvcomp) y se ejecutan esas cosas. 
    [Header("Entradas")]
    public float xInput;
    public float zInput;
    public float mouseX;
    public float mouseY;
    [Header("Componentes")]
    public Movement mvComp;
    public CameraControl currentCam;
    public NormalCamera normalCamera;
    public CombatCamera CombatCamera;
    public Powers powComp;
    public AnimController animC;
    public bool isCombat;
    public Aim aimComp;
    public void Awake() {
        mvComp = GetComponent<Movement>();
        powComp = GetComponent<Powers>();
        animC = GetComponent<AnimController>();
        aimComp = GetComponent<Aim>();
        aimComp.Subscribe(this);
    }
    public void FixedUpdate() { //Input Actions
        if ( Input.GetButton("Horizontal") || Input.GetButton("Vertical") ) {
            xInput = Input.GetAxis("Horizontal");
            Vector3 forw = new Vector3(currentCam.transform.forward.x, 0, currentCam.transform.forward.z);

            zInput = Input.GetAxis("Vertical");
            Vector3 rght = new Vector3(currentCam.transform.right.x, 0, currentCam.transform.right.z);

            mvComp.Move(forw * zInput + rght * xInput);
            animC.walk = true;
        } else            animC.walk = false;
    }
    public void Update() {  //Triggered actions 

        if ( Input.GetButton("Fire2") ) {
            mvComp.Stop();
            powComp.Shoot();
            animC.attack = true;
            //wait until end animation 
        } else {
            animC.attack = false;
        }
        if ( Input.GetAxis("Mouse X") != 0 ) {
            mouseX = Input.GetAxis("Mouse X");
            currentCam.currentX += mouseX;


        }
        if ( Input.GetAxis("Mouse Y") != 0 ) {
            mouseY = Input.GetAxis("Mouse Y");
            currentCam.currentY += mouseY;
        }

        if ( Input.GetButton("Jump") && !mvComp.spammingSpace ) {
            mvComp.Jump();
            animC.jump = true;
        } else {
            animC.jump = false;
        }
        if ( Input.GetButton("Fire1") ) {
            mvComp.Roll();
            animC.roll = true;
        } else
        animC.roll = false;
        if ( Input.GetButton("Fire3") ) {
            xInput = Input.GetAxis("Horizontal");
            Vector3 forw = new Vector3(currentCam.transform.forward.x, 0, currentCam.transform.forward.z);

            zInput = Input.GetAxis("Vertical");
            Vector3 rght = new Vector3(currentCam.transform.right.x, 0, currentCam.transform.right.z);


            mvComp.Running(forw * zInput + rght * xInput);
            animC.run = true;
        } else
        animC.run = false;
        if ( Input.GetButton("one")) {
            powComp.SetPowerType("spring");
        }
        if ( Input.GetButton("two") ) {
            powComp.SetPowerType("summer");
        }
        if ( Input.GetButton("three") ) {
            powComp.SetPowerType("fall");
        }
        if ( Input.GetButton("four") ) {
            powComp.SetPowerType("winter");
        }
        if ( Input.GetButtonDown("E") ) {
            isCombat = !isCombat;
            if ( isCombat )
                aimComp.Combat();
            if ( !isCombat )
                aimComp.Normal();
        }
    }
    public void OnNotify(string str) {
        if (str == "normal" ) {
            currentCam = normalCamera;
        }
        if (str == "combat" ) {
            currentCam = CombatCamera;
        }
    }
}
