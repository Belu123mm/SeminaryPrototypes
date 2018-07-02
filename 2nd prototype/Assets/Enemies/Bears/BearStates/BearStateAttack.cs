using UnityEngine;
using System.Collections;

public class BearStateAttack : BearState
{
    private int _typeOfAttackRandomChance;
    private int _timeBetweenAttacksRandomChance = 2;
    private float _timeOfNoRotationWhileAttack;

    private float _timeOfReposition;
    private int _timeOfRepositionRandomChance;

    public BearStateAttack(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    // Timer para reposition HACER

    public override void Awake()
    {
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.red;
        _rb.useGravity = false;
        _timeOfReposition = Time.time;
        _timeOfRepositionRandomChance = Random.Range(3, 12);
    }

    public override void Execute()
    {
        base.Execute();

        if (Time.time > _timeOfNoRotationWhileAttack + 2) // +2 son los segundos minimos que dura animaciones de ataque
        {
            _dirToGo = _target.transform.position - myBear.transform.position;
            _dirToGo = new Vector3(_dirToGo.x, 0, _dirToGo.z);
            myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
            _rb.velocity = Vector3.zero;
        }

        if (Time.time > _time + _timeBetweenAttacksRandomChance)
        {
            _timeOfNoRotationWhileAttack = Time.time;
            _typeOfAttackRandomChance = Random.Range(0, 4);

            if (_typeOfAttackRandomChance == 0) LightAttack();
            else if (_typeOfAttackRandomChance == 1) LightAttackCombo();
            else if (_typeOfAttackRandomChance == 2) HeavyAttack();
            else HeavyAttackCombo();
        }

        if (Time.time > _timeOfReposition + _timeOfRepositionRandomChance) myBear.toReposition = true;
    }

    public override void Sleep()
    {
        base.Sleep();
        _rb.useGravity = true;
    }

    void LightAttack()
    {
        myBear.AssignCurrentDamageToDeal(_lightAttackDamage);
        myBear.GetComponentInChildren<Animation>().Play("LightAttack1");
        myBear.GetComponent<Renderer>().material.color = Color.blue;
        _timeBetweenAttacksRandomChance = Random.Range(2, 5);
        _time = Time.time;
    }

    void LightAttackCombo()
    {
        myBear.AssignCurrentDamageToDeal(_lightAttackDamage);
        myBear.GetComponentInChildren<Animation>().Play("LightAttack1Combo");
        myBear.GetComponent<Renderer>().material.color = Color.blue;
        _timeBetweenAttacksRandomChance = Random.Range(3, 6);
        _time = Time.time;
    }

    void HeavyAttack()
    {
        myBear.AssignCurrentDamageToDeal(_heavyAttackDamage);
        myBear.GetComponentInChildren<Animation>().Play("HeavyAttack1");
        myBear.GetComponent<Renderer>().material.color = Color.yellow;
        _timeBetweenAttacksRandomChance = Random.Range(3, 5);
        _time = Time.time;
    }

    void HeavyAttackCombo()
    {
        myBear.AssignCurrentDamageToDeal(_heavyAttackDamage);
        myBear.GetComponentInChildren<Animation>().Play("HeavyAttack1Combo");
        myBear.GetComponent<Renderer>().material.color = Color.yellow;
        _timeBetweenAttacksRandomChance = Random.Range(4, 6);
        _time = Time.time;
    }
}
