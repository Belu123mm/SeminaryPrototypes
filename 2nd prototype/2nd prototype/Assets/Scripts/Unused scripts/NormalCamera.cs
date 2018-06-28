using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NormalCamera : CameraControl{
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

