using UnityEngine;
using System.Collections;

public class BearStateCharge : BearState
{
    public BearStateCharge(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.red;
        myBear.AssignCurrentDamageToDeal(_chargeDamage);
        _dirToGo = (_target.transform.position - myBear.transform.position).normalized;
        _dirToGo.y = 0;
        myBear.combatRange = 0.5f;
    }

    public override void Execute()
    {
        base.Execute();

        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
        float velY = _rb.velocity.y;
        _rb.velocity = new Vector3(_dirToGo.x, _dirToGo.y * velY, _dirToGo.z) * _chargeSpeed;
    }

    public override void Sleep()
    {
        base.Sleep();
        myBear.combatRange = myBear.outOfRepositionCombatRange;
        myBear.toCharge = false;
    }
}
