using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBrain : MonoBehaviour {
    public bool ground;
    public float speed 
        , acceleration
        , jumpForce
        , currentSpeed
        //No se que nombre ponerle esta variable, hace -speed o speed segun la orientacion
        , playerSpeed;
    void FixedUpdate () {
        playerSpeed = Input.GetAxisRaw("Horizontal") * speed;

    }
}
