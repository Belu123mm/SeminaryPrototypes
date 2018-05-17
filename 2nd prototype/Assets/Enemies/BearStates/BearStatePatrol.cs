using UnityEngine;
using System.Collections;

public class BearStatePatrol : BearState
{
    public BearStatePatrol(StateMachine sm, Bear b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Patrol");
        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Patrol");
        base.Sleep();
    }
}
