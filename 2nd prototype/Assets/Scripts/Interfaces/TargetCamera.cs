﻿using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class TargetCamera : ICamera {
    public CinemachineFreeLook freeLook;
    public Transform follow;
    public Transform look;
    public CinemachineComposer cTop, cMid, cBottom;
    public float maxDistance;

    public void LoadData( CinemachineFreeLook fl, Transform f, Transform l ) {
        Debug.Log("target");
        freeLook = fl;
        follow = f;
        look = l;
        freeLook.m_Follow = follow;
        freeLook.m_LookAt = look;
        cTop = freeLook.GetRig(0).GetCinemachineComponent<CinemachineComposer>();
        cMid = freeLook.GetRig(1).GetCinemachineComponent<CinemachineComposer>();
        cBottom = freeLook.GetRig(2).GetCinemachineComponent<CinemachineComposer>();
        freeLook.m_XAxis.m_InputAxisName = "";
        freeLook.m_YAxis.m_InputAxisName = "";

        //freeLook.GetRig(0).GetCinemachineComponent<CinemachineComposer>().m_SoftZoneHeight;
    }

    public void LoadTop(float height, float radius, float screenY, float deadWidth,float deadHeight) {

        freeLook.m_Orbits [ 0 ].m_Height = height;
        freeLook.m_Orbits [ 0 ].m_Radius = radius;
        cTop.m_ScreenY = screenY;
        cTop.m_DeadZoneWidth = deadWidth;
        cTop.m_DeadZoneHeight = deadHeight;

    }
    public void LoadMid( float height, float radius, float screenY, float deadWidth, float deadHeight ) {
        freeLook.m_Orbits [ 1 ].m_Height = height;
        freeLook.m_Orbits [ 1 ].m_Radius = radius;
        cMid.m_ScreenY = screenY;
        cMid.m_DeadZoneWidth = deadWidth;
        cMid.m_DeadZoneHeight = deadHeight;


    }
    public void LoadBottom( float height, float radius, float screenY, float deadWidth, float deadHeight ) {
        freeLook.m_Orbits [ 2 ].m_Height = height;
        freeLook.m_Orbits [ 2 ].m_Radius = radius;
        cBottom.m_ScreenY = screenY;
        cBottom.m_DeadZoneWidth = deadWidth;
        cBottom.m_DeadZoneHeight = deadHeight;


    }
    public void OnLateUpdate() {
        freeLook.m_XAxis.Value = Vector3.Angle(follow.position,look.position); //angulo
        freeLook.m_YAxis.Value = Vector3.Distance(look.position,follow.position) / maxDistance;
        //Clamp, y cosas
    }

}
