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
    public float timeIdleToPatrol;
    public float timePatrolToIdle;
    public float knockbackTime;
    public float stunTime;
    public float currentHp;
    public float maxHp;
    public float timeForSeekingPlayer;
    public float distanceFromPlayerToFlee;
    public float knockbackBackForce;
    public float knockbackUpForce;

    private int _damage;
    public int lightAttackDamage;
    public int heavyAttackDamage;


    [HideInInspector]
    public bool playerInSight;
    [HideInInspector]
    public bool playerInRange;
    //[HideInInspector]
    public bool toCharge;
    [HideInInspector]
    public bool playerRecentlySeen;
    [HideInInspector]
    public bool toPatrol;
    [HideInInspector]
    public bool playerIsNear;
    [HideInInspector]
    public bool isKnocked;
    [HideInInspector]
    public bool isStunned;
    [HideInInspector]
    public bool toReposition;
    protected ITree currentTree;

    private bool _targetAdded;

    protected Vector3 _directionToTarget;
    protected float _angleToTarget;
    protected float _distanceToTarget;

    public Aim targetSystem;
    public Lives playerLives;

    [HideInInspector]
    public Vector3 predictedPosition = Vector3.zero;

    [HideInInspector]
    public Vector3 dirToGo;


    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public virtual void Update()
    {
        IsPlayerNear();
        IsPlayerInLOS();
        LineOfSight();
        PlayerInCombatRange();

        // if (Input.GetKeyDown(KeyCode.K)) ApplyKnockback();
    }

    void IsPlayerNear()
    {
        if (_distanceToTarget < distanceFromPlayerToFlee)  playerIsNear = true;
        else                        playerIsNear = false;
    }

    void IsPlayerInLOS()
    {
        if (playerInSight && !_targetAdded)
        {
            _targetAdded = true;
            targetSystem.AddEnemy(this);
        }
        else if (!playerInSight && _targetAdded)
        {
            //Debug.Log("Target false");
            _targetAdded = false;
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

    public void AssignCurrentDamageToDeal(int damage)
    {
        _damage = damage;
    }

    public void DealDamage()
    {
        playerLives.TakeDamage(_damage);
    }

    public void TakeDamage(int damage)
    {
        currentHp -= damage;
    }

    public void ApplyKnockback()
    {
        isKnocked = true;
    }

    public void ApplyStun()
    {
        isStunned = true;
    }

    IEnumerator PlayerRecentlySeen()
    {
        playerRecentlySeen = true;
        yield return new WaitForSeconds(timeForSeekingPlayer);
        playerRecentlySeen = false;
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
