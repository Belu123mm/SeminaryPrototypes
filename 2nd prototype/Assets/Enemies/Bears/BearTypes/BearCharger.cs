using UnityEngine;
using System.Collections;

public class BearCharger : BearGeneric
{
    public override void Start ()
    {
        base.Start();

        bearType = Bear.CHARGER;

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
    }
}
