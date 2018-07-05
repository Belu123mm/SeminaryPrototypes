using UnityEngine;
using System.Collections;

public class BearStateFollow : BearState
{
    public BearStateFollow(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.red;
    }

    public override void Execute()
    {
        base.Execute();

        //Calculamos hacia donde deberia estar mirando
        _dirToGo = (_target.transform.position - myBear.transform.position).normalized;
        _dirToGo.y = 0;
        
        //Vamos modificando el foward hacia la direccion
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
        //Hacemos que avance hacia adelante
        float velY = _rb.velocity.y;
        _rb.velocity = new Vector3(_dirToGo.x, _dirToGo.y * velY, _dirToGo.z) * _speed;
    }

    public override void Sleep()
    {
        base.Sleep();
    }
}
