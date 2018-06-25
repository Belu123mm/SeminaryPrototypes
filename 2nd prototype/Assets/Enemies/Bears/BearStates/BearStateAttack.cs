using UnityEngine;
using System.Collections;

public class BearStateAttack : BearState
{
    private int _typeOfAttackRandomChance;

    public BearStateAttack(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Attack");
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.red;
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

        if (Time.time > _time + Random.Range(2, 4))
        {
            _typeOfAttackRandomChance = Random.Range(0, 4);

            if (_typeOfAttackRandomChance == 0) LightAttack();
            else if (_typeOfAttackRandomChance == 1) LightAttackCombo();
            else if (_typeOfAttackRandomChance == 2) HeavyAttack();
            else HeavyAttackCombo();
        }
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Attack");
        base.Sleep();
        _rb.useGravity = true;
    }

    void LightAttack()
    {
        myBear.damage = 10;
        myBear.GetComponentInChildren<Animation>().Play("LightAttack1");
        myBear.GetComponent<Renderer>().material.color = Color.blue;
        _time = Time.time;
    }

    void LightAttackCombo()
    {
        myBear.damage = 10;
        myBear.GetComponentInChildren<Animation>().Play("LightAttack1Combo");
        myBear.GetComponent<Renderer>().material.color = Color.blue;
        _time = Time.time;
    }

    void HeavyAttack()
    {
        myBear.damage = 25;
        myBear.GetComponent<Renderer>().material.color = Color.yellow;
        _time = Time.time;
    }

    void HeavyAttackCombo()
    {
        myBear.damage = 25;
        myBear.GetComponent<Renderer>().material.color = Color.yellow;
        _time = Time.time;
    }
}
