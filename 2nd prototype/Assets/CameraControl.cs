using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour {
    public float distance;
    public CinemachineVirtualCamera cam;
    [Header("Rangos")]
    public float angleYMin;
    public float angleYMax;
    public float startX;
    public float startY;
    public float cameraSpeedX;
    public float cameraSpeedY;

    [HideInInspector]
    public float currentX;
    [HideInInspector]
    public float currentY;

    public void Start() {
        cam = GetComponent<CinemachineVirtualCamera>();
        currentX = startX;
        currentY = startY;
    }

    private void LateUpdate() {
        currentY = Mathf.Clamp(currentY, angleYMin, angleYMax);
        Vector3 dir = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(currentY * cameraSpeedY , currentX * cameraSpeedX, 0);
        cam.transform.position = cam.LookAt.position + rotation * dir;
    }
}
