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
    }
	
	void Update ()
    {
        _sm.Update();

        if (Input.GetKeyDown(KeyCode.Alpha1))
            _sm.SetState<BearStateIdle>();
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            _sm.SetState<BearStatePatrol>();
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            _sm.SetState<BearStateFollow>();
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            _sm.SetState<BearStateAttack>();
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            _sm.SetState<BearStateSeek>();
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            _sm.SetState<BearStateFlee>();
        else if (Input.GetKeyDown(KeyCode.Alpha7))
            _sm.SetState<BearStateCharge>();
    }
}
