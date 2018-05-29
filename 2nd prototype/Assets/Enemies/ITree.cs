using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITree
{
    void HasHp();
    void PlayerInSight();
    void PlayerInRange();
    void HpToFight();
    void ToCharge();
    void RecentlySeen();
    void ToPatrol();  
}
