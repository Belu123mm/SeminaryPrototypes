﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmoz : MonoBehaviour {
    //Aca esta el gizmos que muestra hacia donde mira la chica. Tiene valores para hacer un offset
    public int xOffset, yOffset, zOffset;
    public void OnDrawGizmos() {
        Gizmos.DrawLine(this.transform.position + new Vector3 (xOffset,yOffset,zOffset), this.transform.position + new Vector3(xOffset, yOffset, zOffset) + this.transform.forward * 5);     //tres horas haciendo esto, OFF
    }
}
