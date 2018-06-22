using UnityEngine;
using System.Collections;

public class BearStateAttack : BearState
{
    private float _time;

    public BearStateAttack(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Attack");
        base.Awake();
        _rb.useGravity = false;
        _time = Time.time;
    }

    public override void Execute()
    {
        base.Execute();

        _dirToGo = _target.transform.position - myBear.transform.position;
        _dirToGo = new Vector3(_dirToGo.x, 0, _dirToGo.z);
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
        _rb.velocity = Vector3.zero;

        if (Time.time > _time + Random.Range(1, 3))
            if (Random.Range(0, 9) < 6) BasicAttack();
            else HeavyAttack();
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Attack");
        base.Sleep();
        _rb.useGravity = true;
    }

    void BasicAttack()
    {
        myBear.GetComponent<Renderer>().material.color = Color.blue;
        myBear.DealDamage(10);
        _time = Time.time;
    }

    void HeavyAttack()
    {
        myBear.GetComponent<Renderer>().material.color = Color.yellow;
        myBear.DealDamage(25);
        _time = Time.time;
    }
}
