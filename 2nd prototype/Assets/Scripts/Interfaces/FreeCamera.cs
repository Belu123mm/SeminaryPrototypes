using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FreeCamera : ICamera  {
    public CinemachineFreeLook freeLook;
    public Transform follow;
    public Transform look;
    public CinemachineComposer top, mid, bottom;

    public void LoadData(CinemachineFreeLook fl,Transform f,Transform l) {
        Debug.Log("frie");
        freeLook = fl;
        follow = f;
        look = l;
        freeLook.m_Follow = follow;
        freeLook.m_LookAt = look;
        top = freeLook.GetRig(0).AddCinemachineComponent<CinemachineComposer>();
        mid = freeLook.GetRig(1).AddCinemachineComponent<CinemachineComposer>();
        bottom = freeLook.GetRig(2).AddCinemachineComponent<CinemachineComposer>();

    }
    public void LoadTop( float height, float radius, float screenY, float deadWidth, float deadHeight ) {
        freeLook.m_Orbits [ 0 ].m_Height = height;
        freeLook.m_Orbits [ 0 ].m_Radius = radius;
        top.m_ScreenY = screenY;
        top.m_DeadZoneWidth = deadWidth;
        top.m_DeadZoneHeight = deadHeight;

    }
    public void LoadMid( float height, float radius, float screenY, float deadWidth, float deadHeight ) {
        freeLook.m_Orbits [ 1 ].m_Height = height;
        freeLook.m_Orbits [ 1 ].m_Radius = radius;
        mid.m_ScreenY = screenY;
        mid.m_DeadZoneWidth = deadWidth;
        mid.m_DeadZoneHeight = deadHeight;
        Debug.Log("2");

    }
    public void LoadBottom( float height, float radius, float screenY, float deadWidth, float deadHeight ) {
        freeLook.m_Orbits [ 2 ].m_Height = height;
        freeLook.m_Orbits [ 2 ].m_Radius = radius;
        bottom.m_ScreenY = screenY;
        bottom.m_DeadZoneWidth = deadWidth;
        bottom.m_DeadZoneHeight = deadHeight;
    }

    public void OnLateUpdate() {
        Debug.Log("free");

    }
}
