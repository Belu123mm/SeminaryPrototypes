using UnityEngine;
using System.Collections;

public class BearStateSeek : BearState
{
    private float _seekRotationSpeed = 0.2f;
    private float _distanceToLastPosition;
    private float _distanceToLastPositionClamp = 1;
    private float _time;

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

        _playerLastPosition = _target.transform.position;
        _distanceToLastPosition = Vector3.Distance(myBear.transform.position, _playerLastPosition);
        _lookLeft = _playerLastPosition + new Vector3(-5, 0, 0);
        _lookRight = _playerLastPosition + new Vector3(5, 0, 0);
    }

    public override void Execute()
    {
        base.Execute();

        if (_distanceToLastPosition > _distanceToLastPositionClamp)
        {
            //Calculamos hacia donde deberia estar mirando
            _dirToGo = _playerLastPosition - myBear.transform.position;
            //Vamos modificando el foward hacia la direccion
            myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _seekRotationSpeed * Time.deltaTime);
            //Hacemos que avance hacia adelante
            float velY = _rb.velocity.y;
            _rb.velocity = new Vector3(_dirToGo.x, _dirToGo.y * velY, _dirToGo.z) * _speed;

            _distanceToLastPosition = Vector3.Distance(myBear.transform.position, _playerLastPosition);
            _time = 0;
        }
        else
        {
            _time = Time.time;
            _rb.velocity = Vector3.zero;
            //myBear.transform.LookAt(_dirToGo);
            //myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, lookLeft, _rotationSpeed * Time.deltaTime);
            myBear.transform.rotation = Quaternion.identity;

            // if (_time < Time.time) LookLeft();
            // else LookRight();

            Debug.Log(_time);
        }
    }

    void LookLeft()
    {
        Debug.Log("HolaLeft");
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, myBear.transform.forward * 2, _seekRotationSpeed * Time.deltaTime);
        
    }

    void LookRight()
    {
        Debug.Log("HolaRight");
        myBear.transform.Rotate(myBear.transform.up, 135);
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Seek");
        base.Sleep();
    }
}
