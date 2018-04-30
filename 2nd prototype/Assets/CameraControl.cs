using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour {

    public float angleYMin = 0.0f;
    public float angleYMax = 50.0f;

    public float distance = 5.0f;

    public float currentX = 0.0f;
    public float currentY = 45.0f;
    public float cameraSpeedX;
    public float cameraSpeedY;

    public CinemachineVirtualCamera cam;
    public void Start() {
        cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update() {
        currentX += Input.GetAxis("Mouse X");
        currentY += Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, angleYMin, angleYMax);

    }

    private void LateUpdate() {
        Vector3 dir = new Vector3(0, 0, distance);
        Quaternion rotation = Quaternion.Euler(currentY * cameraSpeedY , currentX * cameraSpeedX, 0);
        cam.transform.position = cam.LookAt.position + rotation * dir;
    }
}
