using UnityEngine;
using System.Collections;

public class BearStateIdle : BearState
{
    private float _time;

    public BearStateIdle(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Idle");
        base.Awake();
        _time = Time.time;
    }

    public override void Execute()
    {
        base.Execute();
        if (Time.time > _time + 3) myBear.toPatrol = true;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Idle");
        base.Sleep();
    }
}
