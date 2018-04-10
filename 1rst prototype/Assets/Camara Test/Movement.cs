using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour {
    public float movementSpeed;
    public Rigidbody rb;
    public Controller controller;
    public Camera cam;
    public CinemachineBrain cmBrain;
    public CinemachineFreeLook cmFreeLook;
    public void Start() {
        rb = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
        cmBrain = cam.GetComponent<CinemachineBrain>();
        cmFreeLook = cam.GetComponent<CinemachineFreeLook>();
    }
    public void Move( Vector3 direc ) {
        cmBrain.enabled = false;
        cmFreeLook.enabled = false;

        if ( controller == Controller.Tercera ) {

            //Si ves a direcciones distintas, el lookrotation es cero. Hay que hacer un lerp
            rb.MovePosition(Vector3.Lerp(this.transform.position, this.transform.position + direc, 0.5f) * movementSpeed);
            Quaternion rotation = Quaternion.LookRotation(direc);
            rb.MoveRotation(rotation);

        }
        if ( controller == Controller.Primera ) {
            cmBrain.enabled = true;
            cmFreeLook.enabled = true;
        }
    }

}
public enum Controller {
    Tercera,
    Primera
}