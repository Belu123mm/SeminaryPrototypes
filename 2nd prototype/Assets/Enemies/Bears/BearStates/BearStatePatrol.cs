using UnityEngine;
using System.Collections;

public class BearStatePatrol : BearState
{
    private Vector3 _waypoint;

    public BearStatePatrol(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        base.Awake();
        _waypoint = GameObject.FindObjectOfType<WaypointsManager>().GetRandomWaypoint().position;
        _dirToGo = (_waypoint - myBear.transform.position).normalized;
        myBear.GetComponent<Renderer>().material.color = Color.blue;
        _time = Time.time;
    }

    public override void Execute()
    {
        base.Execute();
        if (Time.time > _time + _timePatrolToIdle) myBear.toPatrol = false;

        if ((_waypoint.x - myBear.transform.position.x) < 2 && (_waypoint.z - myBear.transform.position.z) < 2)
        {
            _waypoint = GameObject.FindObjectOfType<WaypointsManager>().GetRandomWaypoint().position;
            _dirToGo = (_waypoint - myBear.transform.position).normalized;
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
