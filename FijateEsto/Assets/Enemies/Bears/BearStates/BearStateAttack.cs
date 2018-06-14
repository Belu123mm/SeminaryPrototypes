using UnityEngine;
using System.Collections;

public class BearStateAttack : BearState
{
    public BearStateAttack(StateMachine sm, BearGeneric b) : base(sm, b)
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

        _dirToGo = _target.transform.position - myBear.transform.position;
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
        _rb.velocity = Vector3.zero;


    }

    public override void Sleep()
    {
        Debug.Log("Salió de Attack");
        base.Sleep();
    }

    void BasicAttack()
    {

    }

    void HeavyAttack()
    {

    }

    void AlternateBasicAndHeavyAttack()
    {

    }
}
