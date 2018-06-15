using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BearGeneric : MonoBehaviour
{
    public StateMachine _sm;

    public Rigidbody rb;

    public GameObject target;
    public float viewDistance;
    public float viewAngle;
    public float combatRange;
    public float speed;
    public float chargeSpeed;
    public float rotationSpeed;
    public float timeOfPrediction;
    public float currentHp;
    public float maxHp;
    public float timeForSeekingPlayer;
    public float distanceFromPlayerToFlee;


    public bool playerInSight;
    public bool playerInRange;
    public bool toCharge;
    public bool playerRecentlySeen;
    public bool toPatrol;
    public bool playerIsNear;
    public bool targetAdded;
    protected ITree currentTree;

    protected Vector3 _directionToTarget;
    protected float _angleToTarget;
    protected float _distanceToTarget;

    public Aim targetSystem;

    [HideInInspector]
    public Vector3 predictedPosition = Vector3.zero;

    [HideInInspector]
    public Vector3 dirToGo;




    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        //targetSystem = FindObjectOfType<Aim>();
    }

    public virtual void Update()
    {
        IsPlayerNear();
        IsPlayerInLOS();
        LineOfSight();
        PlayerInCombatRange();
    }

    void IsPlayerNear()
    {
        if (_distanceToTarget < distanceFromPlayerToFlee)  playerIsNear = true;
        else                        playerIsNear = false;
    }

    void IsPlayerInLOS()
    {
        if (playerInSight && !targetAdded)
        {
            //Debug.Log("Target true");
            targetAdded = true;
            targetSystem.AddEnemy(this);
        }
        else if (!playerInSight && targetAdded)
        {
            //Debug.Log("Target false");
            targetAdded = false;
            targetSystem.RemoveEnemy(this);
        }
    }

    void LineOfSight()
    {
        _distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (_distanceToTarget > viewDistance)
        {
            if (playerInSight) StartCoroutine(PlayerRecentlySeen());
            playerInSight = false;
            return;
        }

        _directionToTarget = (target.transform.position - transform.position).normalized;

        _angleToTarget = Vector3.Angle(transform.forward, _directionToTarget);

        if (_angleToTarget <= viewAngle)
        {
            RaycastHit raycastInfo;
            bool obstaclesBetween = false;

            if (Physics.Raycast(transform.position, _directionToTarget, out raycastInfo, _distanceToTarget))
                if (raycastInfo.collider.gameObject.layer == Layers.WORLD)
                    obstaclesBetween = true;

            if (!obstaclesBetween)
                playerInSight = true;
            else
            {
                if (playerInSight) StartCoroutine(PlayerRecentlySeen());
                playerInSight = false;
            }
        }
        else
        {
            if (playerInSight) StartCoroutine(PlayerRecentlySeen());
            playerInSight = false;
        }
    }

    void PlayerInCombatRange()
    {
        if(playerInSight && _distanceToTarget < combatRange)
            playerInRange = true;
        else
            playerInRange = false;
    }

    IEnumerator PlayerRecentlySeen()
    {
        playerRecentlySeen = true;
        yield return new WaitForSeconds(timeForSeekingPlayer);
        playerRecentlySeen = false;
    }

    public virtual void AlternateIdleAndPatrol()
    {

    }

    void OnDrawGizmos()
    {
        if (playerInSight)
            Gizmos.color = Color.green;
        else
            Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, target.transform.position);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewDistance);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, transform.position + (transform.forward * viewDistance));

        Vector3 rightLimit = Quaternion.AngleAxis(viewAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (rightLimit * viewDistance));

        Vector3 leftLimit = Quaternion.AngleAxis(-viewAngle, transform.up) * transform.forward;
        Gizmos.DrawLine(transform.position, transform.position + (leftLimit * viewDistance));
    }
}
