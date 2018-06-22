using UnityEngine;
using System.Collections;

public class BearStatePatrol : BearState
{
    private float _time;

    public BearStatePatrol(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Patrol");
        base.Awake();
        _time = Time.time;
    }

    public override void Execute()
    {
        base.Execute();
        if (Time.time > _time + 6) myBear.toPatrol = false;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Patrol");
        base.Sleep();
    }
}
