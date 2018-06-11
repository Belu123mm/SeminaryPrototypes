using UnityEngine;
using System.Collections;

public class BearStateFollow : BearState
{
    public BearStateFollow(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Follow");
        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();

        //Calculamos hacia donde deberia estar mirando
        _dirToGo = _target.transform.position - myBear.transform.position;
        //Vamos modificando el foward hacia la direccion
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
        //Hacemos que avance hacia adelante
        float velY = _rb.velocity.y;
        _rb.velocity = new Vector3(_dirToGo.x, _dirToGo.y * velY, _dirToGo.z) * _speed;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Follow");
        base.Sleep();
    }
}
