using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour{
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
    public string state;
    public int value;

    //[HideInInspector]
    public float currentX;
    //[HideInInspector]
    public float currentY;

    public virtual void Start() {        
        cam = GetComponent<CinemachineVirtualCamera>();
        aimCont = FindObjectOfType<Aim>();

    }
    public void OnNotify(string st) {
        state = st;
    }
}
