using UnityEngine;
using System.Collections;

public class BearStateRepositioning : BearState
{
    private Vector3 _waypoint;

    public BearStateRepositioning(StateMachine sm, BearGeneric b) : base(sm, b)
    {
    }

    public override void Awake()
    {
        base.Awake();
        _waypoint = GameObject.FindObjectOfType<WaypointsManager>().GetRandomWaypoint().position;
        _dirToGo = (_waypoint - myBear.transform.position).normalized;
        myBear.GetComponent<Renderer>().material.color = Color.red;
        _time = Time.time;
        myBear.viewAngle = myBear.combatViewAngle;
        myBear.viewDistance = myBear.repositioningViewDistance;
        myBear.combatRange = myBear.repositionCombatRange;
    }

    public override void Execute()
    {
        base.Execute();

        

        if ((_waypoint.x - myBear.transform.position.x) < 2 && (_waypoint.z - myBear.transform.position.z) < 2)
        {
            _waypoint = GameObject.FindObjectOfType<WaypointsManager>().GetRandomWaypoint().position;
            _dirToGo = (_waypoint - myBear.transform.position).normalized;
        }

        _dirToGo.y = 0;
        myBear.transform.forward = Vector3.Lerp(myBear.transform.forward, _dirToGo, _rotationSpeed * Time.deltaTime);
        float velY = _rb.velocity.y;
        _rb.velocity = new Vector3(_dirToGo.x, _dirToGo.y * velY, _dirToGo.z) * _chargeSpeed;

        if (Time.time > _time + _repositionTime)
        {
            _dirToGo = (_target.transform.position - myBear.transform.position).normalized;
            myBear.transform.forward = _dirToGo;
            myBear.combatRange = myBear.outOfRepositionCombatRange;
            myBear.toReposition = false;
            myBear.toCharge = true;
        }
    }

    public override void Sleep()
    {
        base.Sleep();
        myBear.viewAngle = myBear.outOfCombatViewAngle;
        myBear.viewDistance = myBear.outOfRepositioningViewDistance;
        myBear.combatRange = myBear.outOfRepositionCombatRange;
        myBear.toReposition = false;
    }
}
