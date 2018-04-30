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
        float _tempJumpForce = jumpForce;
        rb.AddForce(Vector3.up * jumpForce);
        spammingSpace = true;

        if ( spammingSpace ) {
            _tempJumpForce -= 1;
        }
        if ( ground ) {
            ground = false;
        }
    }
    public void Roll() {
        Vector3 dashVelocity = Vector3.Scale(transform.forward, dashDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
        rb.AddForce(dashVelocity, ForceMode.VelocityChange);
    }
    public void OnCollisionEnter( Collision collision ) {
        if ( collision.gameObject.layer == LayerMask.NameToLayer("Level") && !ground ) {
            ground = true;
            spammingSpace = false;

        }
    }
}