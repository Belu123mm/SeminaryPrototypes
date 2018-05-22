using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {
    public NewTargetedCamera cam;
    private void OnTriggerEnter ( Collider other ) {
        if ( other.gameObject.layer == LayerMask.NameToLayer("Enemi") ) {
            AreaCollider sphere = other.GetComponent<AreaCollider>();
            cam.SetCamera(sphere.enemy,sphere.distance);
        }
    }
    private void OnTriggerExit( Collider other ) {
        if ( other.gameObject.layer == LayerMask.NameToLayer("Enemi") ) {
            cam.Off();
        }
    }
}
