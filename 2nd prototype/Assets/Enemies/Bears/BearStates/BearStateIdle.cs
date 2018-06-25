using UnityEngine;
using System.Collections;

public class BearStateIdle : BearState
{
    public BearStateIdle(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Idle");
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.blue;
        _time = Time.time;
    }

    public override void Execute()
    {
        base.Execute();
        if (Time.time > _time + _timeIdleToPatrol) myBear.toPatrol = true;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Idle");
        base.Sleep();
    }
}
