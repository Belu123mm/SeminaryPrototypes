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
        _dirToGo = -(_target.transform.position - myBear.transform.position);
        //Vamos ajustando el foward
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
        //Avanzamos hacia adelante
        myBear.transform.position += myBear.transform.forward * _speed * Time.deltaTime;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Flee");
        base.Sleep();
    }
}
