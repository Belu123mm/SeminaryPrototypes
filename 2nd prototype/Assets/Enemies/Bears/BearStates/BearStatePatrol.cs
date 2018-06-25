using UnityEngine;
using System.Collections;

public class BearStatePatrol : BearState
{
    public BearStatePatrol(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Patrol");
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.blue;
        _time = Time.time;
    }

    public override void Execute()
    {
        base.Execute();
        if (Time.time > _time + _timePatrolToIdle) myBear.toPatrol = false;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Patrol");
        base.Sleep();
    }
}
