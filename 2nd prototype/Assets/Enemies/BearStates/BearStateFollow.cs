using UnityEngine;
using System.Collections;

public class BearStateFollow : BearState
{
    public BearStateFollow(StateMachine sm, Bear b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Follow");
        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Follow");
        base.Sleep();
    }
}
