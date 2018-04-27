using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour {
    //Aca se colocan los inputs y se llama a movement (mvcomp) y se ejecutan esas cosas. 
    public float xInput;
    public float zInput;
    public Movement mvComp;
    public void Start() {
        mvComp = GetComponent<Movement>();
    }
    public void FixedUpdate() { 
        if (Input.GetButton("Horizontal")) {
            xInput = Input.GetAxis("Horizontal");
            zInput = Input.GetAxis("Vertical");
            mvComp.Rotate(zInput);
        }
        if (Input.GetButton("Vertical") ) {
            xInput = Input.GetAxis("Vertical");
            mvComp.Move(xInput);
        }


    }
}
