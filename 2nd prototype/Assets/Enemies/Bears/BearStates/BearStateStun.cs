using UnityEngine;
using System.Collections;

public class BearStateStun : BearState
{
    public BearStateStun(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.green;
        _time = Time.time;
    }

    public override void Execute()
    {
        base.Execute();
        if (Time.time > _time + _stunTime) myBear.isStunned = false;
    }

    public override void Sleep()
    {
        base.Sleep();
    }
}
