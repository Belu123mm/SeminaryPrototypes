using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour {
    public Rigidbody Rigidbody;
    [Header("Velocidades")]
    public float movementSpeed;
    [Range(1f, 3f)]
    public float runningSpeed;
    [Range(0f, 1f)]
    public float rotationSpeed;
    [Header("Fuerzas")]
    public float jumpForce;
    public float rollDistance;
    [Header("Datos Binarios")]
    public bool ground;
    public bool spammingSpace;

    public void Start() {
        Rigidbody = GetComponent<Rigidbody>();
    }
    public void Move( Vector3 direc ) {
        Rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direc), rotationSpeed));
        Rigidbody.MovePosition(this.transform.position + (direc * movementSpeed * Time.fixedDeltaTime));

    }
    public void Jump() {
        Rigidbody.AddForce(Vector3.up * jumpForce);
        spammingSpace = true;

        if ( ground ) {
            ground = false;
        }
    }
    public void Roll() { //Esto lo hace una vez asi que no hace falta que se guarde en variablez
        Vector3 _rollVelocity = Vector3.Scale(transform.forward, rollDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime)));
        Rigidbody.AddForce(_rollVelocity, ForceMode.VelocityChange);
    }
    public void Running( Vector3 direc ) {
        Rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direc), rotationSpeed));
        Rigidbody.MovePosition(this.transform.position + (direc * movementSpeed * runningSpeed * Time.fixedDeltaTime));

    }
    public void OnCollisionEnter( Collision collision ) {
        if ( collision.gameObject.layer == LayerMask.NameToLayer("Level") && !ground ) {
            ground = true;
            spammingSpace = false;
        }
    }
    public void Stop() {
        Rigidbody.velocity = Vector3.zero;
    }
}