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
    public bool active;

    public void Start() {
        cam = GetComponent<CinemachineFreeLook>();

    }
    public void Update() {
        if ( active ) {
            float side = Vector3.Angle(Vector3.forward, new Vector3(follow.position.x - look.position.x, 0, follow.position.z - look.position.z));
            float angle = Vector3.Angle(Vector3.right, new Vector3(follow.position.x - look.position.x, 0, follow.position.z - look.position.z));
            if ( side < 90 ) {
                cam.m_XAxis.Value = -angle - 90; //angulo
                print("Lado1");
            } else if ( side > 90 ) {
                cam.m_XAxis.Value = angle - 90; //angulo
                print("Lado2");

            }
            print(side);

            cam.m_YAxis.Value = Vector3.Distance(look.position, follow.position) / maxDistance;
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