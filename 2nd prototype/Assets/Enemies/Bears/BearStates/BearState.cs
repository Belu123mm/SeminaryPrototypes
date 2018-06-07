using UnityEngine;
using System.Collections;

public class BearState : State
{
    protected BearGeneric myBear;

    protected Rigidbody _rb;
    protected GameObject _target;
    protected float _speed;
    protected float _chargeSpeed;
    protected float _rotationSpeed;
    protected float _timeOfPrediction;

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
        _predictedPosition = myBear.predictedPosition;
        _dirToGo = myBear.dirToGo;
    }
}
