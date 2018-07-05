using UnityEngine;
using System.Collections;

public class BearStateKnockback : BearState
{
    public BearStateKnockback(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.cyan;
        _time = Time.time;
        _rb.AddForce(myBear.knockbackDirection * _knockbackBackForce + myBear.transform.up * _knockbackUpForce, ForceMode.Impulse);
    }

    public override void Execute()
    {
        base.Execute();
        if (Time.time > _time + _knockbackTime) myBear.isKnocked = false;
    }

    public override void Sleep()
    {
        base.Sleep();
    }
}
