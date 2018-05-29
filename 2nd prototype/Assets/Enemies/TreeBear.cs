using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBear : ITree
{
    BearGeneric b;

    public TreeBear(BearGeneric body)
    {
        b = body;
    }

    public void HasHp()
    {
        if (b.currentHp > 0) PlayerInSight();

        else if (!b._sm.IsActualState<BearStateDie>()) b._sm.SetState<BearStateDie>();
    }

    public void PlayerInSight()
    {
        if (b.playerInSight) PlayerInRange();

        else RecentlySeen();
    }

    public void PlayerInRange()
    {
        if (b.playerInRange) HpToFight();

        else ToCharge();
    }

    public void HpToFight()
    {
        if (b.currentHp > 25)
        {
            if (!b._sm.IsActualState<BearStateAttack>()) b._sm.SetState<BearStateAttack>();
        }

        else if (!b._sm.IsActualState<BearStateFlee>()) b._sm.SetState<BearStateFlee>();
    }

    public void ToCharge()
    {
        if (b.toCharge)
        {
            if (!b._sm.IsActualState<BearStateCharge>()) b._sm.SetState<BearStateCharge>();
        }

        else if (!b._sm.IsActualState<BearStateFollow>()) b._sm.SetState<BearStateFollow>();
    }

    public void RecentlySeen()
    {
        if (b.playerRecentlySeen)
        {
            if (!b._sm.IsActualState<BearStateSeek>()) b._sm.SetState<BearStateSeek>();
        }

        else ToPatrol();
    }

    public void ToPatrol()
    {
        if (b.toPatrol)
        {
            if (!b._sm.IsActualState<BearStatePatrol>()) b._sm.SetState<BearStatePatrol>();
        }

        else if (!b._sm.IsActualState<BearStateIdle>()) b._sm.SetState<BearStateIdle>();
    }
}
