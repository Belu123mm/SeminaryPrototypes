using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ModelPlayer {
    //mono
    public Rigidbody Rigidbody;
    public Transform Transform;
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
    public TargetedCamera camera;
    public int life;

    public ModelPlayer( Rigidbody rb, Transform tr) {
        Rigidbody = rb;
        Transform = tr;
    }

    public void Move( Vector3 direc ) {
        Rigidbody.MoveRotation(Quaternion.Slerp(Transform.rotation, Quaternion.LookRotation(direc), rotationSpeed));
        Rigidbody.MovePosition(Transform.position + (direc * movementSpeed * Time.fixedDeltaTime));
    }
    public void Jump() {
        Rigidbody.AddForce(Vector3.up * jumpForce);
        spammingSpace = true;

        if ( ground ) {
            ground = false;
        }
    }
    public void Roll() { //Esto lo hace una vez asi que no hace falta que se guarde en variablez
        Vector3 _rollVelocity = Vector3.Scale(Transform.forward, rollDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime)));
        Rigidbody.AddForce(_rollVelocity, ForceMode.VelocityChange);
    }
    public void Running( Vector3 direc ) {
        Rigidbody.MoveRotation(Quaternion.Slerp(Transform.rotation, Quaternion.LookRotation(direc), rotationSpeed));
        Rigidbody.MovePosition(Transform.position + (direc * movementSpeed * runningSpeed * Time.fixedDeltaTime));

    }

}
