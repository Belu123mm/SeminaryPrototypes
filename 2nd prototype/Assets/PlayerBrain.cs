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
    public CameraControl cam;
    public AllThings temp;
    public void Start() {
        mvComp = GetComponent<Movement>();
        cam = FindObjectOfType<CameraControl>();
    }
    public void FixedUpdate() { //Input Actions
        if ( Input.GetButton("Horizontal") || Input.GetButton("Vertical") ) {
            xInput = Input.GetAxis("Horizontal");
            Vector3 forw = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);

            zInput = Input.GetAxis("Vertical");
            Vector3 rght = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);

            mvComp.Move(forw * zInput + rght * xInput);
        }

    }
    public void Update() {  //Triggered actions 

        if ( Input.GetAxis("Mouse X") != 0 ) {
            mouseX = Input.GetAxis("Mouse X");
            cam.currentX += mouseX;
        }
        if ( Input.GetAxis("Mouse Y") != 0 ) {
            mouseY = Input.GetAxis("Mouse Y");
            cam.currentY += mouseY;
        }

        if ( Input.GetButton("Jump") && !mvComp.spammingSpace ) {
            mvComp.Jump();
        }
        if ( Input.GetButton("Fire1") ) {
            mvComp.Roll();
        }
        if ( Input.GetButton("Fire2") ) {
            temp.Attack();
        }
        if ( Input.GetButton("Fire3") ) {
            xInput = Input.GetAxis("Horizontal");
            Vector3 forw = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);

            zInput = Input.GetAxis("Vertical");
            Vector3 rght = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);


            mvComp.Running(forw * zInput + rght * xInput);
        }
    }
}
