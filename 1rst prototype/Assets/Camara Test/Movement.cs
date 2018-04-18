using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour {
    //Aca se colocan todas las funciones de movimiento que ejecuta el brain. 
    public float movementSpeed;
    public float rotationSpeed;
    public Rigidbody rb;
    public Camera cam;
    public void Start() {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
    }
    public void Move( float direc ) {
        rb.MovePosition(Vector3.Lerp(this.transform.position, this.transform.position + this.transform.forward   * direc, 0.5f) * movementSpeed);
    }
    public void Rotate(Vector3 direc) {

        //Aca es la rotacion. usar el transform.rotate y pasarlo en el rb.moverotation. Cualquier cosa mandarle mail a alan, para que mande el ejemplo que me dio en clase. 
        //rb.MovePosition(Vector3.Lerp(this.transform.position, this.transform.position + direc, 0.5f) * rotationSpeed);

        Quaternion rotation = Quaternion.LookRotation(direc);
        print(rotation);
        rb.MoveRotation(rotation );
    }
}


