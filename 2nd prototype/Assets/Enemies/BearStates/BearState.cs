using UnityEngine;
using System.Collections;

public class BearState : State
{
    protected Bear myBear;

    public BearState(StateMachine sm, Bear b) : base(sm)
    {
        myBear = b;
    }
}
