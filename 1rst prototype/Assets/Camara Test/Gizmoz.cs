using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmoz : MonoBehaviour {
    public void OnDrawGizmos() {
        Gizmos.DrawLine(this.transform.position, this.transform.position + this.transform.forward * 5);     //tres horas haciendo esto, OFF
    }
}
