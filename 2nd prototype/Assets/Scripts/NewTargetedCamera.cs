using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

/*
[RequireComponent(typeof(CinemachineVirtualCamera))]
public class NewTargetedCamera : MonoBehaviour {
public float distance;
public CinemachineVirtualCamera cam;
public Aim aimCont;
[Header("Rangos")]
public float angleYMin;
public float angleYMax;
public float startX;
public float startY;
public float cameraSpeedX;
public float cameraSpeedY;
public List<Transform> lookTargets = new List<Transform>();


//[HideInInspector]
public float currentX;
//[HideInInspector]
public float currentY;

public void Start() {
    cam = GetComponent<CinemachineVirtualCamera>();
    aimCont = FindObjectOfType<Aim>();
    currentX = startX;
    currentY = startY;
}
private void LateUpdate() {
    //cam.m_LookAt = lookTarget();

    currentY = Mathf.Clamp(currentY, angleYMin, angleYMax);
    Vector3 dir = new Vector3(0, 0, distance);
    Quaternion rotation = Quaternion.Euler(currentY * cameraSpeedY, currentX * cameraSpeedX, 0);
    cam.transform.position = cam.LookAt.position + rotation * dir;
}

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


}
*/

//[RequireComponent(typeof(CinemachineVirtualCamera))]
public class NewTargetedCamera : MonoBehaviour
{
    //public float distance;
    public CinemachineFreeLook cam;
    public Aim aimCont;
    [Header("Rangos")]
    //public float angleYMin;
    //public float angleYMax;
    public float startX;
    public float startY;
    //public float cameraSpeedX;
    //public float cameraSpeedY;
    public Transform middlePoint;
    public Transform avatar;

    //[HideInInspector]
    //public float currentX;
    //[HideInInspector]
    //public float currentY;
    public List<Transform> lookTargets = new List<Transform>();

    public void Start()
    {
        //cam.m_Follow = follow;
        cam = GetComponent<CinemachineFreeLook>();
        aimCont = FindObjectOfType<Aim>();
        //currentX = startX;
        //currentY = startY;



        AddTarget(avatar);
        cam.m_Follow = avatar;
    }
    private void LateUpdate()
    {
        cam.m_LookAt = lookTarget();

        //currentY = Mathf.Clamp(currentY, angleYMin, angleYMax);
        //Vector3 dir = new Vector3(0, 0, distance);
        //Quaternion rotation = Quaternion.Euler(currentY * cameraSpeedY, currentX * cameraSpeedX, 0);
        //cam.transform.position = cam.LookAt.position + rotation * dir;
    }

    //Todo esto de targets esta correcto
    public Transform lookTarget()
    {
        if (lookTargets.Count == 1)
        {
            return lookTargets[0];
        }
        else if (lookTargets.Count > 1)
        {
            Bounds bounds = new Bounds(lookTargets[0].position, Vector3.zero);
            foreach (var t in lookTargets)
            {
                bounds.Encapsulate(t.position);
            }
            Transform transf = this.transform;
            transf.position = bounds.center;
            return transf;
        }
        else return null;

    }
    public void AddTarget(Transform t)
    {
        if (!lookTargets.Contains(t))
        {
            lookTargets.Add(t);
        }
    }
    public void RemoveTarget(Transform t)
    {
        if (lookTargets.Contains(t))
        {
            lookTargets.Remove(t);
        }
    }


}

