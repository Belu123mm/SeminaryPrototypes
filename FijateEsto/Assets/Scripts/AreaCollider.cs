using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class AreaCollider : MonoBehaviour {
    SphereCollider sphere;
    public Transform enemy;
    public float distance;
	// Use this for initialization
	void Start () {
        sphere = GetComponent<SphereCollider>();
        distance = sphere.radius;
	}
	
}
