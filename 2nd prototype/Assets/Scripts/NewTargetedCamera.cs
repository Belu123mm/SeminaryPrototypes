using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class NewTargetedCamera : MonoBehaviour {
    public float distance;

}

/*
    public class CameraControl : MonoBehaviour, IObserver {
    public CinemachineVirtualCamera cam;
    public Aim aimCont;
    [Header("Rangos")]
    public float angleYMin;
    public float angleYMax;
    public float startX;
    public float startY;
    public float cameraSpeedX;
    public float cameraSpeedY;
    public string state;
    public int value;

    //[HideInInspector]
    public float currentX;
    //[HideInInspector]
    public float currentY;

    public virtual void Start() {
        cam = GetComponent<CinemachineVirtualCamera>();
        aimCont = FindObjectOfType<Aim>();
        aimCont.Subscribe(this);
    }
    public void OnNotify( string st ) {
        state = st;
    }
}

public class NormalCamera : CameraControl {
    public override void Start() {
        base.Start();
        print("Started");
        currentX = startX;
        currentY = startY;
    }
    public void Update() {
        //   if (state == "")
    }
    private void LateUpdate() {
        currentY = Mathf.Clamp(currentY, angleYMin, angleYMax);
        Vector3 dir = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(currentY * cameraSpeedY, currentX * cameraSpeedX, 0);
        cam.transform.position = cam.LookAt.position + rotation * dir;
    }
}
[RequireComponent(typeof(CinemachineFreeLook))]
public class NewTargetedCamera : MonoBehaviour {
    //funciona el tema de los targets. empieza amirar a un punto medio.
    //si el xinput es mayor al limite, clampeas y poner quaternion y toda la cosa, si no no :V
    public CinemachineFreeLook freeLook;
    public Transform follow;
    public float startX;
    public float xInput;



    public float angleYMin;
    public float angleYMax;
    public List<Transform> lookTargets = new List<Transform>();

    public void Awake() {

    }

    public void Start() {
        freeLook = GetComponent<CinemachineFreeLook>();
        freeLook.m_Follow = follow;
        xInput = startX;
    }

    public void Update() {
    }

    public void LateUpdate() {
        if ( Input.GetAxis("Mouse X") != 0 )
            xInput += Input.GetAxis("Mouse X") * 6;
        freeLook.m_LookAt = lookTarget();
        if ( xInput > 360 ) {
            xInput -= 360;
        }
        if ( xInput < -360 )
            xInput += 360;
    }

    //amazing
    public Transform lookTarget() {
        if ( lookTargets.Count == 1 ) {
            return lookTargets [ 0 ];
        } else if ( lookTargets.Count > 1 ) {
            Bounds bounds = new Bounds(lookTargets [ 0 ].position, Vector3.zero);
            foreach ( var t in lookTargets ) {
                bounds.Encapsulate(t.position);
            }
            Transform transf = this.transform;
            transf.position = bounds.center;
            return transf;
        } else return null;

    }

    public void AddTarget( Transform t ) {
        if ( !lookTargets.Contains(t) ) {
            lookTargets.Add(t);
        }
    }
    public void RemoveTarget( Transform t ) {
        if ( lookTargets.Contains(t) ) {
            lookTargets.Remove(t);
        }
    }
    public void Clamp() {
        freeLook.m_XAxis.Value = Mathf.Clamp(freeLook.m_XAxis.Value, angleYMin, angleYMax);
    }

}
*/