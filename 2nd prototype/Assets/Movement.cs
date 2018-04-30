using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float movementSpeed;
    public float rotationSpeed;     //No se usa
    public float rollForce;
    public float jumpForce;
    public float dashDistance;
    public bool ground;
    public bool spammingSpace;

    public Rigidbody rb;
    public void Start() {
        rb = GetComponent<Rigidbody>();
    }
    public void Move( Vector3 direc ) {
        rb.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direc), rotationSpeed));
        rb.MovePosition(this.transform.position + (direc * movementSpeed * Time.fixedDeltaTime));
    }
    public void Jump() {

    }
    public void Roll() {
    }
}
