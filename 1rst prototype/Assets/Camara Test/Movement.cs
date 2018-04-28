using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour {
    //Aca se colocan todas las funciones de movimiento que ejecuta el brain. 
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
    public void Move( float direc ) {
        rb.MovePosition(Vector3.Lerp(this.transform.position, this.transform.position + this.transform.forward   * direc, 0.5f) * movementSpeed);
    }
    public void Rotate(float direc) {

        //Aca es la rotacion. usar el transform.rotate y pasarlo en el rb.moverotation. Cualquier cosa mandarle mail a alan, para que mande el ejemplo que me dio en clase. 
        //rb.MovePosition(Vector3.Lerp(this.transform.position, this.transform.position + direc, 0.5f) * rotationSpeed);

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation((this.transform.right * direc)), rotationSpeed);

      /*  Quaternion rotation = Quaternion.LookRotation(this.transform.right * direc * (rotationSpeed / 10));
        print(rotation);
        rb.MoveRotation(rotation );
        */
    }
    /*
     public void Moving(float forw, float right) {
        Vector3 _inputs = new Vector3(forw, 0, right);
        if (_inputs != Vector3.zero)
            transform.forward = _inputs;
        rb.MovePosition(this.transform.position + _inputs + cam.transform.forward + this.transform.right * movementSpeed * Time.fixedDeltaTime);
        if ( right != 0 )
            cam.transform.position += _inputs;
    }
    */
    public void TestMoving(Vector3 direc) {
        rb.MovePosition(this.transform.position + (direc * movementSpeed * Time.fixedDeltaTime));
        print( direc * movementSpeed * Time.fixedDeltaTime);
       // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direc), rotationSpeed);     //Increible que esta cosa arruinara todo muy fuerte 
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
        if (collision.gameObject.layer == LayerMask.NameToLayer("Level") && !ground ) {
            ground = true;
            spammingSpace = false;

        }
    }
}


