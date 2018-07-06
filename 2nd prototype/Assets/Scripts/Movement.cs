using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Movement : MonoBehaviour {
    public Rigidbody Rigidbody;
    [Header("Velocidades")]
    public float movementSpeed;
    private float _speedAfterJump;
    [Range(1f, 3f)]
    public float runningSpeed;
    [Range(0f, 1f)]
    public float rotationSpeed;
    [Header("Fuerzas")]
    public float jumpForce;
    public float rollDistance;
    public float pushDistance;
    [Header("Datos Binarios")]
    public bool ground;
    public bool spammingSpace;
    public Camera cam;
    public NewTargetedCamera newcam;
    public int maxStamina;
    public int currentStamina;
    public UIController UIContr;
    public int jumpValue;
    public int runValue;
    public int rollValue;
    public int fillingValue;
    public bool fillingStamina;
    public bool running;
    public bool rolling;
    public bool hit;
    public float delayHit;
    public float timeToRoll;
    public float timer;
    public void Start() {
        Rigidbody = GetComponent<Rigidbody>();
        cam = FindObjectOfType<Camera>();
        UIContr = FindObjectOfType<UIController>();

        UIContr.SetMaxStamina(maxStamina);
        currentStamina = maxStamina;
        UIContr.SetStamina(currentStamina);

        _speedAfterJump = movementSpeed;
    }
    public void Update() {
        timer += Time.deltaTime;
        if ( currentStamina < maxStamina && ground && !running ) {
            fillingStamina = true;
        } else {
            fillingStamina = false;
        }
        if ( fillingStamina ) {
            currentStamina += fillingValue;
            UIContr.SetStamina(currentStamina);
        }
        if ( timeToRoll < timer ) {
            rolling = false;
        }
    }
    public void Move( Vector3 direc ) {
        Rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direc), rotationSpeed));
        Rigidbody.MovePosition(this.transform.position + (direc * movementSpeed * Time.fixedDeltaTime));

    }
    public void MoveOnCombat( Vector3 direc ) {
        Rigidbody.MovePosition(this.transform.position + (direc * movementSpeed * Time.fixedDeltaTime));
        Rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(cam.transform.forward.x, this.transform.forward.y, cam.transform.forward.z)), rotationSpeed));
    }

    public void Jump() {
        Rigidbody.AddForce(Vector3.up * jumpForce);
        spammingSpace = true;

        if ( ground ) {
            ground = false;
        }
        currentStamina -= jumpValue;
        UIContr.SetStamina(currentStamina);
    }

    public void StopSpeed() {
        movementSpeed = movementSpeed / 2;
        Invoke("RestartSpeed", 0.4f);
    }

    public void RestartSpeed() {
        movementSpeed = _speedAfterJump;
    }
    public void SideRoll(Vector3 direc ) {
        Vector3 _rollVelocity = Vector3.Scale(direc + transform.up, rollDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime), 1.5f, (Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime)));
        Rigidbody.AddForce(_rollVelocity, ForceMode.Impulse);
        Rigidbody.velocity = Vector3.zero;
        currentStamina -= rollValue;
        UIContr.SetStamina(currentStamina);

    }

    public void Roll() { //Esto lo hace una vez asi que no hace falta que se guarde en variablez
        Vector3 _rollVelocity = Vector3.Scale(transform.forward + transform.up, rollDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime), 1.5f, (Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime)));
        Rigidbody.AddForce(_rollVelocity, ForceMode.Impulse);
        Rigidbody.velocity = Vector3.zero;
        currentStamina -= rollValue;
        UIContr.SetStamina(currentStamina);
    }
    public void Push() {
        Vector3 _rollVelocity = Vector3.Scale(-transform.forward + transform.up, pushDistance * new Vector3((Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime), 1, (Mathf.Log(1f / (Time.deltaTime * Rigidbody.drag + 1)) / -Time.deltaTime)));
        Rigidbody.AddForce(_rollVelocity, ForceMode.Impulse);
    }
    public void Running( Vector3 direc ) {

        Rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direc), rotationSpeed));
        Rigidbody.MovePosition(this.transform.position + (direc * movementSpeed * runningSpeed * Time.fixedDeltaTime));
        currentStamina -= runValue;
        UIContr.SetStamina(currentStamina);
    }
    public void RunningOnCombat( Vector3 direc ) {

        //Rigidbody.MoveRotation(Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direc), rotationSpeed));
        Rigidbody.MovePosition(this.transform.position + (direc * movementSpeed * runningSpeed * Time.fixedDeltaTime));
        currentStamina -= runValue;
        UIContr.SetStamina(currentStamina);
    }

    public void OnCollisionEnter( Collision collision ) {
        if ( collision.gameObject.layer == Layers.WORLD && !ground ) {
            ground = true;
            StopSpeed();
            spammingSpace = false;
        }

    }
}