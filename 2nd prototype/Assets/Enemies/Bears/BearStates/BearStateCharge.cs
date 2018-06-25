using UnityEngine;
using System.Collections;

public class BearStateCharge : BearState
{
    public BearStateCharge(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        Debug.Log("Entró a Charge");
        base.Awake();
        myBear.GetComponent<Renderer>().material.color = Color.magenta;
    }

    public override void Execute()
    {
        base.Execute();

        // Obtenemos la posicion a la que debemos apuntar
        // _predictedPosition = _target.transform.position + _target.transform.forward * _target.movementSpeed * _timeOfPrediction;
        
        //Hacemos que se rote hacia esa direccion
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _predictedPosition - myBear.transform.position, _rotationSpeed * Time.deltaTime);

        //Hacemos que avance
        myBear.transform.position += myBear.transform.forward * _speed * _chargeSpeed * Time.deltaTime;
    }

    public override void Sleep()
    {
        Debug.Log("Salió de Charge");
        base.Sleep();
    }
}
