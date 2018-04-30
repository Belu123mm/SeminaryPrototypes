using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour {
    //Aca se colocan los inputs y se llama a movement (mvcomp) y se ejecutan esas cosas. 
    public float xInput;
    public float zInput;
    public Movement mvComp;
    public Camera cam;
    public void Start() {
        mvComp = GetComponent<Movement>();
        cam = FindObjectOfType<Camera>();

    }
    public void FixedUpdate() { //Input Actions
        /*
        if (Input.GetButton("Horizontal")) {
            xInput = Input.GetAxis("Horizontal");
            zInput = Input.GetAxis("Vertical");
            mvComp.Rotate(zInput);
        }
        if (Input.GetButton("Vertical") ) {
            xInput = Input.GetAxis("Vertical");
            mvComp.Move(xInput);
        }
        */
        if ( Input.GetButton("Horizontal") || Input.GetButton("Vertical") ) {
            xInput = Input.GetAxis("Horizontal");
            zInput = Input.GetAxis("Vertical");
            Vector3 forw = new Vector3(cam.transform.forward.x, 0, cam.transform.forward.z);
            Vector3 rght = new Vector3(cam.transform.right.x, 0, cam.transform.right.z);
            //mvComp.TestMoving(forw * zInput + rght * xInput);
            mvComp.Move(forw * zInput + rght * xInput);
        }
    }
    public void Update() {  //Triggered actions 
        
    
        if (Input.GetButton("Jump") && !mvComp.spammingSpace ) {
            mvComp.Jump();
        }
        if ( Input.GetButton("Fire1") ) {
            mvComp.Roll();
        }
        /*
        _inputX = Input.GetAxis("Horizontal");
        _inputZ = Input.GetAxis("Vertical");

        var forward = _cam.transform.forward;
        var right = _cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        var desiredMoveDirection = forward * _inputZ + right * _inputX;

    */


    }
}
