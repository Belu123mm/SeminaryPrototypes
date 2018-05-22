using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TargetCamera : MonoBehaviour {
    public CinemachineFreeLook freeLook;
    public Transform follow;
    public Transform look;
    public CinemachineComposer cTop, cMid, cBottom;
    public float maxDistance;
    public bool active;

    public void OnLateUpdate() {
        while ( active ) {
        freeLook.m_XAxis.Value = Vector3.Angle(follow.position,look.position); //angulo
        freeLook.m_YAxis.Value = Vector3.Distance(look.position,follow.position) / maxDistance;

        }
        //Clamp, y cosas
    }

}
