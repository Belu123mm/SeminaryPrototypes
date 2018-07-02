using UnityEngine;
using System.Collections;

public class BearState : State
{
    protected BearGeneric myBear;

    protected Rigidbody _rb;
    protected GameObject _target;
    protected float _time;
    protected float _speed;
    protected float _chargeSpeed;
    protected float _rotationSpeed;
    protected float _timeOfPrediction;
    protected float _timeIdleToPatrol;
    protected float _timePatrolToIdle;
    protected float _knockbackTime;
    protected float _stunTime;
    protected float _repositionTime;
    protected float _knockbackBackForce;
    protected float _knockbackUpForce;
    protected int _lightAttackDamage;
    protected int _heavyAttackDamage;

    protected Vector3 _predictedPosition = Vector3.zero;
    protected Vector3 _dirToGo;

    public BearState(StateMachine sm, BearGeneric b) : base(sm)
    {
        myBear = b;
        _rb = myBear.rb;
        _target = myBear.target;
        _speed = myBear.speed;
        _chargeSpeed = myBear.chargeSpeed;
        _rotationSpeed = myBear.rotationSpeed;
        _timeOfPrediction = myBear.timeOfPrediction;
        _timeIdleToPatrol = myBear.timeIdleToPatrol;
        _timePatrolToIdle = myBear.timePatrolToIdle;
        _knockbackTime = myBear.knockbackTime;
        _stunTime = myBear.stunTime;
        _repositionTime = myBear.repositionTime;
        _knockbackBackForce = myBear.knockbackBackForce;
        _knockbackUpForce = myBear.knockbackUpForce;
        _lightAttackDamage = myBear.lightAttackDamage;
        _heavyAttackDamage = myBear.heavyAttackDamage;
        _predictedPosition = myBear.predictedPosition;
        _dirToGo = myBear.dirToGo;
    }
}
