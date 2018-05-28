using UnityEngine;
using System.Collections;

public class BearStateDie : BearState
{
    public BearStateDie(StateMachine sm, Bear b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Die");
        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Die");
        base.Sleep();
    }
}
