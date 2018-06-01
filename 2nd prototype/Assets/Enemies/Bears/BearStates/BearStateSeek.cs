using UnityEngine;
using System.Collections;

public class BearStateSeek : BearState
{
    private float _seekRotationSpeed = 50;
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
            myBear.transform.position += myBear.transform.forward * _speed * Time.deltaTime;

            _distanceToLastPosition = Vector3.Distance(myBear.transform.position, _playerLastPosition);
        }
        else
        {
            //myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, lookLeft, _rotationSpeed * Time.deltaTime);
            //new WaitForSeconds(3);
        }
    }

    IEnumerator LookAround()
    {

        yield return new WaitForSeconds(3);
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Seek");
        base.Sleep();
    }
}
