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
        
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Idle");
        base.Sleep();
    }
}
