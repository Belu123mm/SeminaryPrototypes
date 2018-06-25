using UnityEngine;
using System.Collections;

public class BearStateKnockback : BearState
{
    public BearStateKnockback(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Knockback");
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.cyan;
        _time = Time.time;
        _rb.AddForce(-myBear.transform.forward * _knockbackBackForce + myBear.transform.up * _knockbackUpForce, ForceMode.Impulse);
    }

    public override void Execute()
    {
        base.Execute();
        if (Time.time > _time + _knockbackTime) myBear.isKnocked = false;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Knockback");
        base.Sleep();
    }
}
