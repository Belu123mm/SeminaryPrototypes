﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineFreeLook))]
public class NewTargetedCamera : MonoBehaviour {

    public CinemachineFreeLook cam;
    public Transform follow;
    public Transform look;
    public float maxDistance;
    public float actualDistance;
    public bool active;

    public void Start() {
        cam = GetComponent<CinemachineFreeLook>();

    }
    public void Update() {
        if ( active ) {
            actualDistance = Vector3.Distance(follow.position, look.position);
            float side = Vector3.Angle(Vector3.forward, new Vector3(follow.position.x - look.position.x, 0, follow.position.z - look.position.z));
            float angle = Vector3.Angle(Vector3.right, new Vector3(follow.position.x - look.position.x, 0, follow.position.z - look.position.z));
            if ( side < 90 ) {
                cam.m_XAxis.Value = -angle - 90; //angulo
            } else if ( side > 90 ) {
                cam.m_XAxis.Value = angle - 90; //angulo

            }

            cam.m_YAxis.Value = -(actualDistance / maxDistance) + 1;
        }
    }
    public void On( Transform _look, float dist ) {
        follow = cam.Follow;
        cam.m_LookAt = _look;
        look = cam.LookAt;
        maxDistance = dist;
        cam.Priority = 15;
        cam.m_XAxis.m_InputAxisName = "";
        cam.m_YAxis.m_InputAxisName = "";
        active = true;
    }
    public void Off() {
        //cam.LookAt = follow;
        cam.Priority = 5;
        //cam.m_XAxis.m_InputAxisName = "Mouse X";
        //cam.m_YAxis.m_InputAxisName = "Mouse Y";
        active = false;
    }
}