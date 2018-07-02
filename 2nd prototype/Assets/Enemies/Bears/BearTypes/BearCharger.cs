using UnityEngine;
using System.Collections;

public class BearCharger : BearGeneric
{
    private bool _resetTimer;
    private float _time;
    private float _timeToReposition;

    public override void Start ()
    {
        base.Start();

        _sm = new StateMachine();
        _sm.AddState(new BearStateIdle(_sm, this));
        _sm.AddState(new BearStatePatrol(_sm, this));
        _sm.AddState(new BearStateFollow(_sm, this));
        _sm.AddState(new BearStateAttack(_sm, this));
        _sm.AddState(new BearStateSeek(_sm, this));
        _sm.AddState(new BearStateFlee(_sm, this));
        _sm.AddState(new BearStateCharge(_sm, this));
        _sm.AddState(new BearStateKnockback(_sm, this));
        _sm.AddState(new BearStateStun(_sm, this));
        _sm.AddState(new BearStateRepositioning(_sm, this));
        _sm.AddState(new BearStateDie(_sm, this));

        currentTree = new DecisionTreeBearGeneric(this);
    }
	
	public override void Update ()
    {
        base.Update();

        _sm.Update();
        currentTree.HasHpToLive();
        ActivateReposition();
    }

    public void ActivateReposition()
    {
        if (!toReposition)
        {
            if (playerInSight)
            {
                //if (Time.time > _time + Random.nge(8, 16)) toReposition = true;
            }

            else _time = Time.time;
        }

        else DesactivateReposition();
    }

    public void DesactivateReposition()
    {

        if (toReposition)
        {
            if (Time.time > _time + 3) toReposition = false;
        }

        else _time = Time.time;

    }
}
