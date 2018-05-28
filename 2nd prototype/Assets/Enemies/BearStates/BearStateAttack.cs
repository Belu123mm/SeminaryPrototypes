using UnityEngine;
using System.Collections;

public class BearStateAttack : BearState
{
    public BearStateAttack(StateMachine sm, Bear b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Attack");
        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Attack");
        base.Sleep();
    }
}
