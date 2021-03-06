﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Camera cam;
    public NewTargetedCamera targCam;
    public List<BearGeneric> enemis = new List<BearGeneric>();
    public bool aim;
    public LayerMask mask;
    public BearGeneric bear;

    public void Update() {
        if ( bear ) {

            if ( Vector3.Distance(transform.position, bear.transform.position) > bear.viewDistance ) {
                Targeted();
            }
        }
    }
    public void CallRay()
    {
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity, mask))
        {
                BearGeneric bear = hit.collider.gameObject.GetComponent<BearGeneric>();

                if (enemis.Contains(bear))
                {
                    aim = true;
                    targCam.On(bear.transform,bear.viewDistance);
                this.bear = bear;
                }
        }

        Debug.DrawRay(cam.transform.position, cam.transform.forward * 10, Color.white, 100);//BLANCO
    }

    public void Targeted()
    {
        if (!aim)
            CallRay();
        else
        {
            targCam.Off();
            aim = false;
            bear = null;
        }
    }

    public void AddEnemy(BearGeneric enm)
    {
        enemis.Add(enm);
    }

    public void RemoveEnemy(BearGeneric enm)
    {
        if (enemis.Contains(enm))   enemis.Remove(enm);
    }
}
