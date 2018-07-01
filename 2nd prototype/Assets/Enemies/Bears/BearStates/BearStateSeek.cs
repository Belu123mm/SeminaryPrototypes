using UnityEngine;
using System.Collections;

public class BearStateSeek : BearState
{
    private float _seekRotationSpeed = 3f;
    private float _distanceToLastPosition;
    private float _distanceToLastPositionClamp = 1;

    private Vector3 _playerLastPosition;
    private Vector3 _lookPosition1;
    private Vector3 _lookPosition2;
    private Vector3 _lookDirection;

    public BearStateSeek(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.yellow;

        _playerLastPosition = _target.transform.position;
        _distanceToLastPosition = Vector3.Distance(myBear.transform.position, _playerLastPosition);
        _dirToGo = _playerLastPosition - myBear.transform.position;
        _lookPosition1 = GameObject.FindObjectOfType<WaypointsManager>().GetRandomWaypoint().position;
        _lookPosition2 = GameObject.FindObjectOfType<WaypointsManager>().GetRandomWaypoint().position;
    }

    public override void Execute()
    {
        base.Execute();

        if (_distanceToLastPosition > _distanceToLastPositionClamp)
        {
            myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _seekRotationSpeed * Time.deltaTime);
            float velY = 0;
            _rb.velocity = new Vector3(_dirToGo.x, _dirToGo.y * velY, _dirToGo.z).normalized * _speed;

            _distanceToLastPosition = Vector3.Distance(myBear.transform.position, _playerLastPosition);
            _time = Time.time;
        }
        else
        {
            _rb.velocity = Vector3.zero;
            _rb.freezeRotation = true;

            if (Time.time < _time + 3) LookLeft();
            else if (Time.time < _time + 6) LookRight();
            else myBear.playerRecentlySeen = false;
        }
    }

    void LookLeft()
    {
        _lookDirection = (_lookPosition1 - myBear.transform.position).normalized;
        _lookDirection.y = 0;
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _lookDirection, _seekRotationSpeed * Time.deltaTime);
    }

    void LookRight()
    {
        _lookDirection = (_lookPosition2 - myBear.transform.position).normalized;
        _lookDirection.y = 0;
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _lookDirection, _seekRotationSpeed * Time.deltaTime);
    }

    public override void Sleep()
    {
        base.Sleep();
    }
}
