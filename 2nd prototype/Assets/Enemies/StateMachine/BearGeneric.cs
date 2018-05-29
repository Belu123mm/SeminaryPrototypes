using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BearGeneric : MonoBehaviour {

    public StateMachine _sm;

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
    protected ITree currentTree;

    [HideInInspector]
    public Vector3 predictedPosition = Vector3.zero;

    [HideInInspector]
    public Vector3 dirToGo;

}
