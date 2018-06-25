using UnityEngine;
using System.Collections;

public class BearStateDie : BearState
{
    public BearStateDie(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Die");
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.black;
        _time = Time.time;
    }

    public override void Execute()
    {
        base.Execute();

        if (Time.time > _time + 3) Destroy();
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Die");
        base.Sleep();
    }

    void Destroy()
    {
        myBear.gameObject.SetActive(false);
    }
}
