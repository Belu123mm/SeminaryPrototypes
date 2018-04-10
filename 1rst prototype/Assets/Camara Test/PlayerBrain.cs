using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour {
    public float xInput;
    public float zInput;
    public Movement mvComp;
    public void Start() {
        mvComp = GetComponent<Movement>();
    }
    public void Update() {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical") ) {
        xInput = Input.GetAxis("Horizontal");
        zInput = Input.GetAxis("Vertical");
        mvComp.Move(new Vector3(xInput, 0, zInput));

        }
    }
}
