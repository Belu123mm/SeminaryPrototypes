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

        //myBear.transform.rotation = Quaternion.Euler(new Vector3(0, myBear.transform.forward.z, 0));
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Idle");
        base.Sleep();
    }
}
