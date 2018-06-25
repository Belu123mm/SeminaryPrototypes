using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearSmall : BearGeneric
{

	void Start ()
    {
        _sm = new StateMachine();
        _sm.AddState(new BearStateIdle(_sm, this));
        _sm.AddState(new BearStatePatrol(_sm, this));
        _sm.AddState(new BearStateFollow(_sm, this));
        _sm.AddState(new BearStateAttack(_sm, this));
        _sm.AddState(new BearStateSeek(_sm, this));
        _sm.AddState(new BearStateFlee(_sm, this));
        _sm.AddState(new BearStateCharge(_sm, this));
        _sm.AddState(new BearStateDie(_sm, this));

        currentTree = new DecisionTreeBearGeneric(this);
    }

    public override void Update()
    {
        base.Update();

        _sm.Update();
        currentTree.HasHpToLive();
    }
}
