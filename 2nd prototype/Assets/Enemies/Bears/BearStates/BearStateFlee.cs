using UnityEngine;
using System.Collections;

public class BearStateFlee : BearState
{
    private Transform _waypoint;

    public BearStateFlee(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        base.Awake();
        _waypoint = GameObject.FindObjectOfType<WaypointsManager>().GetRandomWaypoint();
        _dirToGo = (_waypoint.position - myBear.transform.position).normalized;
        myBear.GetComponent<Renderer>().material.color = Color.magenta;
    }

    public override void Execute()
    {
        base.Execute();

        if((_waypoint.position.x - myBear.transform.position.x) < 2 && (_waypoint.position.z - myBear.transform.position.z) < 2)
        {
            _waypoint = GameObject.FindObjectOfType<WaypointsManager>().GetRandomWaypoint();
            _dirToGo = (_waypoint.position - myBear.transform.position).normalized;
        }

        _dirToGo.y = 0;
        //Vamos ajustando el foward
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
        //Avanzamos hacia adelante
        float velY = _rb.velocity.y;
        _rb.velocity = new Vector3(_dirToGo.x, _dirToGo.y * velY, _dirToGo.z) * _speed;
    }

    public override void Sleep()
    {
        base.Sleep();
    }
}
