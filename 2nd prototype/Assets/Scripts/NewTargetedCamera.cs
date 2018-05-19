using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class NewTargetedCamera : MonoBehaviour {

    public ICamera currentCamera;
    public ICamera freeCamera, targetCamera;
    public Transform follow, look, target;
    public CinemachineFreeLook cam;
    public bool free;

    public Vector3 _dirToTarget;
    private float _angleToTarget;
    private float _distanceToTarget;
    public float viewAngle;
    public float viewDistance;




    public void Start() {
        cam = GetComponent<CinemachineFreeLook>();

        freeCamera = new FreeCamera();
        targetCamera = new TargetCamera();

        CallFreeCamera(); 
    }
    private void LateUpdate() {
        _angleToTarget = Vector3.Angle(follow.transform.forward, _dirToTarget);
        _distanceToTarget = Vector3.Distance(follow.transform.position, target.transform.position);
        if (_angleToTarget <= viewAngle && _distanceToTarget <= viewDistance && !free)
        {
            print("trueaim");
            CallTargetedCamera(target);
            free = true;
        }
        else if (_angleToTarget >= viewAngle && _distanceToTarget >= viewDistance && free)
        {
            print("falseaim");
            CallFreeCamera();
            free = false;

        }
        currentCamera.OnLateUpdate();
    }

    public void CallTargetedCamera( Transform l ) {
        currentCamera = targetCamera;
        currentCamera.LoadData(cam, follow, l);
        currentCamera.LoadTop(4.5f, 4.5f, 0.35f, 0.9f, 0.7f);
        currentCamera.LoadMid(2.5f, 5, 0.3f, 0.1f, 0.7f);
        currentCamera.LoadBottom(1.5f,6,0.28f,0.9f,0.7f);
        

    }
    public void CallFreeCamera() {
        currentCamera = freeCamera;
        currentCamera.LoadData(cam, follow, look);
        currentCamera.LoadTop(4.5f, 6, 0.5f, 0.026f, 0.04f);
        currentCamera.LoadMid(2.5f, 6, 0.56f, 0.023f, 0.036f);
        currentCamera.LoadBottom(0.46f, 6, 0.6f, 0.023f, 0.040f);
    }

    public void Aim() {
        _angleToTarget = Vector3.Angle(follow.transform.forward, _dirToTarget);
        _distanceToTarget = Vector3.Distance(follow.transform.position, target.transform.position);
        if (_angleToTarget <= viewAngle && _distanceToTarget <= viewDistance && !free)
        {
            print("trueaim");
            CallTargetedCamera(target);
            free = true;
        }
        else if (_angleToTarget >= viewAngle && _distanceToTarget >= viewDistance && free)
        {
            print("falseaim");
            CallFreeCamera();
        free = false;

        }
    }


    //La dirección desde un punto a otro es: Posición Final - Posición Inicial NORMALIZADA

    //Vector3.Angle nos da el ángulo entre dos direcciones

    //Vector3.Distance nos da la distancia entre dos posiciones
    //Es lo mismo que hacer: Posición Final - Posición Inicial y sacar la magnitud del vector
    //_distanceToTarget = (target.transform.position - transform.position).magnitude;


    //Si entra en el angulo y en el rango de vision 

    void OnDrawGizmos() {
        /*
        Dibujamos una línea desde el NPC hasta el enemigo.
        Va a ser de color verde si lo esta viendo, roja sino.
        */
        Gizmos.DrawLine(transform.position, target.transform.position);

        /*
        Dibujamos los límites del campo de visión.
        */
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * viewDistance));

        Vector3 rightLimit = Quaternion.AngleAxis(viewAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (rightLimit * viewDistance));

        Vector3 leftLimit = Quaternion.AngleAxis(-viewAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (leftLimit * viewDistance));
    }




}

