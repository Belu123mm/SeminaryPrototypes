using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class ModelPlayer  {
    //mono
    public Rigidbody Rigidbody;
    public Transform Transform;
    public float movementSpeed;


    public event Action<float> OnMovement = delegate { };

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
    public Camera Camera;
    public int life;

    //Update

    //Model
    public ModelPlayer( Rigidbody rb, Transform tr,Camera cam,float mspeed) {
        Rigidbody = rb;
        Transform = tr;
        Camera = cam;
        movementSpeed = mspeed;
    }

    //Funciones
    public void Move( float xInput, float zInput ) {

        Vector3 forw = new Vector3((Transform.position - Camera.transform.position).normalized.x, 0, (Transform.position - Camera.transform.position).normalized.z);
        Vector3 rght = Vector3.Cross(Transform.up, (Transform.position - Camera.transform.position).normalized);

        Vector3 direc = forw * zInput + rght * xInput;

        Vector2 vel = new Vector2(xInput, zInput);
        Rigidbody.MoveRotation(Quaternion.Slerp(Transform.rotation, Quaternion.LookRotation(direc), rotationSpeed));
        Rigidbody.MovePosition(Transform.position + (direc * vel.magnitude * movementSpeed * Time.fixedDeltaTime));
        OnMovement(vel.magnitude / 1.414214f);
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
