using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {
    public Camera cam;
    public NewTargetedCamera targCam;
    public List<Enemy> enemis = new List<Enemy>();
    public bool aim;
    public LayerMask mask;
    public void CallRay() {
        RaycastHit hit;
        if ( Physics.Raycast(cam.transform.position, (cam.transform.forward), out hit, Mathf.Infinity,mask) ) {
                Enemy emn = hit.collider.gameObject.GetComponent<Enemy>();
                if ( enemis.Contains(emn)){
                    print("Hitted");
                    aim = true;
                    targCam.On(emn.transform,emn.distance);
                }
                
        }
        Debug.DrawRay(cam.transform.position, cam.transform.forward * 10, Color.white, 100);//BLANCO
    }
    public void Targeted() {
        if ( !aim ) {
            CallRay();
        } else {
            targCam.Off();
            aim = false;
        }
    }
    public void AddEnemy( Enemy enm ) {
        enemis.Add(enm);
    }
    public void RemoveEnemy( Enemy enm ) {
        if ( enemis.Contains(enm) ) {
            enemis.Remove(enm);
        }
    }
}
