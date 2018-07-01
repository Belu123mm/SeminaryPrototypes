using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmAttackManager : MonoBehaviour
{
    BearGeneric _thisBear;

	void Start ()
    {
        _thisBear = GetComponentInParent<BearGeneric>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == Layers.PLAYER)
        {
            _thisBear.DealDamage();
        }
    }
}
