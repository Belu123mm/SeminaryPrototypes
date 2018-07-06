using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear
{
    public static int FIGHTER = 0;
    public static int PATROLLER = 1;
    public static int CHARGER = 2;
}

public abstract class BearGeneric : MonoBehaviour
{
    [HideInInspector]
    public int bearType;

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
    public float repositionTime;
    public float stunTime;
    public float currentHp;
    public float maxHp;
    public float timeForSeekingPlayer;
    public float distanceFromPlayerToFlee;
    public float knockbackBackForce;
    public float knockbackUpForce;
    [HideInInspector]
    public Vector3 knockbackDirection;

    private int _damage;
    public int lightAttackDamage;
    public int heavyAttackDamage;

    [HideInInspector]
    public float outOfCombatViewAngle;
    [HideInInspector]
    public float combatViewAngle = 180;
    [HideInInspector]
    public float outOfRepositioningViewDistance;
    [HideInInspector]
    public float repositioningViewDistance = 50;
    [HideInInspector]
    public float outOfRepositionCombatRange;
    [HideInInspector]
    public float repositionCombatRange = 50;

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
    

    protected Vector3 _directionToTarget;
    protected float _angleToTarget;
    [HideInInspector]
    public float distanceToTarget;

    public Aim targetSystem;
    public Lives playerLives;

    [HideInInspector]
    public Vector3 predictedPosition = Vector3.zero;

    [HideInInspector]
    public Vector3 dirToGo;


    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();

        targetSystem.AddEnemy(this);
        outOfCombatViewAngle = viewAngle;
        outOfRepositioningViewDistance = viewDistance;
        outOfRepositionCombatRange = combatRange;
    }

    public virtual void Update()
    {
        IsPlayerNear();
        LineOfSight();
        PlayerInCombatRange();
    }

    void IsPlayerNear()
    {
        if ( distanceToTarget < distanceFromPlayerToFlee ) playerIsNear = true;
        else { playerIsNear = false; targetSystem.Targeted(); }
    }

    void LineOfSight()
    {
        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        
        if (distanceToTarget > viewDistance)
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

            if (Physics.Raycast(transform.position, _directionToTarget, out raycastInfo, distanceToTarget))
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
        if(playerInSight && distanceToTarget < combatRange)
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

    public void ApplyKnockback(Vector3 powerDirection)
    {
        knockbackDirection = powerDirection;
        isKnocked = true;
        StartCoroutine(PlayerRecentlySeen());
    }

    public void ApplyStun()
    {
        isStunned = true;
        StartCoroutine(PlayerRecentlySeen());
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
