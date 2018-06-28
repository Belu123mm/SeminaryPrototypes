using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITree
{
    void HasHpToLive();
    void IsPlayerInSight();
    void IsPlayerInRange();
    void HasHpToFight();
    void IsAbleToCharge();
    void HasPlayerBeenRecentlySeen();
    void IsGoingToPatrol();  
}
