using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour {
    public float movementSpeed;
    public Rigidbody rb;
    public Camera cam;
    public void Start() {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }
    public void Move( Vector3 direc ) {
        rb.MovePosition(Vector3.Lerp(this.transform.position, this.transform.position + direc, 0.5f) * movementSpeed);
        Quaternion rotation = Quaternion.LookRotation(direc);
        rb.MoveRotation(rotation);

    }
}


