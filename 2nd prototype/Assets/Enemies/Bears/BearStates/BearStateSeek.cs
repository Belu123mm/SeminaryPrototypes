using UnityEngine;
using System.Collections;

public class BearStateSeek : BearState
{
    private float _seekRotationSpeed = 20f;
    private float _distanceToLastPosition;
    private float _distanceToLastPositionClamp = 1;

    private Vector3 _playerLastPosition;
    private Vector3 _lookLeft;
    private Vector3 _lookRight;

    public BearStateSeek(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Seek");
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.yellow;

        _playerLastPosition = _target.transform.position;
        _distanceToLastPosition = Vector3.Distance(myBear.transform.position, _playerLastPosition);
        _dirToGo = _playerLastPosition - myBear.transform.position;
        _lookLeft = _playerLastPosition + new Vector3(-5, 0, 0);
        _lookRight = _playerLastPosition + new Vector3(5, 0, 0);
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
        Debug.Log("Turn Left");
        //myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, new Vector3(myBear.transform.position.x + 5, myBear.transform.position.y, myBear.transform.position.z + 5), _seekRotationSpeed * Time.deltaTime);
        //myBear.transform.LookAt(Vector3.Lerp(myBear.transform.forward, myBear.transform.forward * 2, _seekRotationSpeed * Time.deltaTime));
    }

    void LookRight()
    {
        Debug.Log("Turn Right");
        //myBear.transform.Rotate(myBear.transform.up, 135);
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Seek");
        base.Sleep();
    }
}
