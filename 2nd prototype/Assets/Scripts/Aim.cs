using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {
    public NewTargetedCamera cam;
    public List<Enemy> enemis = new List<Enemy>();
        public void CallRay() {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position,(cam.transform.position - this.transform.position), out hit,Mathf.Infinity)){
            //aca va lo del hit que no me acuerdo como va xd 
            //cam.On(sphere.enemy,sphere.distance);
            cam.Off();

        }
    }
    public void AddEnemy(Enemy enm ) {
        enemis.Add(enm);
    }
    public void RemoveEnemy(Enemy enm ) {
        if ( enemis.Contains(enm) ) {
            enemis.Remove(enm);
        }
    }
}
