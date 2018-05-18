using UnityEngine;
using System.Collections;

public class BearStateSeek : BearState
{
    public BearStateSeek(StateMachine sm, Bear b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Seek");
        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Seek");
        base.Sleep();
    }
}
