using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecisionTreeBearGeneric : ITree
{
    BearGeneric _thisBear;

    public DecisionTreeBearGeneric(BearGeneric body)
    {
        _thisBear = body;
    }

    public void HasHpToLive()
    {
        if (_thisBear.currentHp > 0) IsKnocked();

        else if (!_thisBear._sm.IsActualState<BearStateDie>()) _thisBear._sm.SetState<BearStateDie>();
    }

    public void IsKnocked()
    {
        if (_thisBear.isKnocked)
        {
            if (!_thisBear._sm.IsActualState<BearStateKnockback>()) _thisBear._sm.SetState<BearStateKnockback>();
        }

        else IsStunned();
    }

    public void IsStunned()
    {
        if (_thisBear.isStunned)
        {
            if (!_thisBear._sm.IsActualState<BearStateStun>()) _thisBear._sm.SetState<BearStateStun>();
        }

        else IsPlayerInSight();
    }

    public void IsPlayerInSight()
    {
        if (_thisBear.playerInSight) HasHpToFight();

        else IsFleing();
    }

    public void HasHpToFight()
    {
        if (_thisBear.currentHp > 25) IsPlayerInRange();

        else if (!_thisBear._sm.IsActualState<BearStateFlee>()) _thisBear._sm.SetState<BearStateFlee>();
    }

    public void IsPlayerInRange()
    {
        if (_thisBear.playerInRange)
        {
            if (!_thisBear._sm.IsActualState<BearStateAttack>()) _thisBear._sm.SetState<BearStateAttack>();
        }

        else IsAbleToCharge();
    }

    public void IsAbleToCharge()
    {
        if (_thisBear.toCharge)
        {
            if (!_thisBear._sm.IsActualState<BearStateCharge>()) _thisBear._sm.SetState<BearStateCharge>();
        }

        else if (!_thisBear._sm.IsActualState<BearStateFollow>()) _thisBear._sm.SetState<BearStateFollow>();
    }

    public void IsFleing()
    {
        if (!_thisBear._sm.IsActualState<BearStateFlee>()) HasPlayerBeenRecentlySeen();

        else if (!_thisBear.playerIsNear) IsGoingToPatrol();
    }

    public void HasPlayerBeenRecentlySeen()
    {
        if (_thisBear.playerRecentlySeen)
        {
            if (!_thisBear._sm.IsActualState<BearStateSeek>()) _thisBear._sm.SetState<BearStateSeek>();
        }

        else IsGoingToPatrol();
    }

    public void IsGoingToPatrol()
    {
        if (_thisBear.toPatrol)
        {
            if (!_thisBear._sm.IsActualState<BearStatePatrol>()) _thisBear._sm.SetState<BearStatePatrol>();
        }

        else if (!_thisBear._sm.IsActualState<BearStateIdle>()) _thisBear._sm.SetState<BearStateIdle>();
    }
}
