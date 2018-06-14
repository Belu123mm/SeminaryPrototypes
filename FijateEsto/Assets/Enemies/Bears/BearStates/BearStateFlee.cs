using UnityEngine;
using System.Collections;

public class BearStateFlee : BearState
{
    public BearStateFlee(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Flee");
        base.Awake();
    }

    public override void Execute()
    {
        base.Execute();

        //Calculamos la direccion hacia la que tenemos que ir
        _dirToGo = -(_target.transform.position - myBear.transform.position).normalized;
        //Vamos ajustando el foward
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
        //Avanzamos hacia adelante
        float velY = _rb.velocity.y;
        _rb.velocity = new Vector3(_dirToGo.x, _dirToGo.y * velY, _dirToGo.z) * _speed;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Flee");
        base.Sleep();
    }
}
