using UnityEngine;
using System.Collections;

public class BearStateFollow : BearState
{
    public BearStateFollow(StateMachine sm, Bear b) : base(sm, b)
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
        myBear.transform.position += myBear.transform.forward * _speed * Time.deltaTime;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Follow");
        base.Sleep();
    }
}
