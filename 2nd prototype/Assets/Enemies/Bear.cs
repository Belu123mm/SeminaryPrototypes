using UnityEngine;
using System.Collections;

public class Bear : MonoBehaviour
{
    StateMachine _sm;

    public Movement target;
    public float speed;
    public float chargeSpeed;
    public float rotationSpeed;
    public float timeOfPrediction;
    public float currentHp;

    public bool playerInSight;
    public bool playerInRange;
    public bool toCharge;
    public bool playerRecentlySeen;
    public bool toPatrol;
    

    [HideInInspector]
    public Vector3 predictedPosition = Vector3.zero;

    [HideInInspector]
    public Vector3 dirToGo;

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
    }
	
	void Update ()
    {
        _sm.Update();

        HasHp();    // Update Decision Tree
    }

    #region Decision Tree

    public void HasHp()
    {
        if (currentHp > 0)      PlayerInSight();

        else                    if (!_sm.IsActualState<BearStateDie>()) _sm.SetState<BearStateDie>();
    }

    public void PlayerInSight()
    {
        if (playerInSight)      PlayerInRange();

        else                    RecentlySeen();
    }

    public void PlayerInRange()
    {
        if (playerInRange)      HpToFight();

        else                    ToCharge();
    }

    public void HpToFight()
    {
        if (currentHp > 25)
        {
            if (!_sm.IsActualState<BearStateAttack>()) _sm.SetState<BearStateAttack>();
        }

        else if (!_sm.IsActualState<BearStateFlee>()) _sm.SetState<BearStateFlee>();
    }

    public void ToCharge()
    {
        if (toCharge)
        {
            if (!_sm.IsActualState<BearStateCharge>()) _sm.SetState<BearStateCharge>();
        }

        else if (!_sm.IsActualState<BearStateFollow>()) _sm.SetState<BearStateFollow>();
    }

    public void RecentlySeen()
    {
        if (playerRecentlySeen)
        {
            if (!_sm.IsActualState<BearStateSeek>()) _sm.SetState<BearStateSeek>();
        }

        else ToPatrol();
    }

    public void ToPatrol()
    {
        if (toPatrol)
        {
            if (!_sm.IsActualState<BearStatePatrol>()) _sm.SetState<BearStatePatrol>();
        }

        else if (!_sm.IsActualState<BearStateIdle>()) _sm.SetState<BearStateIdle>();
    }

    #endregion
}
