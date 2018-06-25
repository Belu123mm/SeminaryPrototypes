using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAttackManager : MonoBehaviour
{
    BearGeneric _thisBear;

	// Use this for initialization
	void Start ()
    {
        _thisBear = GetComponentInParent<BearGeneric>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == Layers.PLAYER)
        {
            _thisBear.DealDamage();
        }
    }
}
