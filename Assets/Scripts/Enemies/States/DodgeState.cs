using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgeState : State
{
    protected D_DodgeState stateData;

    protected bool performCloseRangeAction;
    protected bool isPPlayerInMaxAgroRange;
    protected bool isGrounded;
    protected bool isDodgeOver;
    public DodgeState(Entity etity, FiniteStateMachine stateMachine, string animGBooName, D_DodgeState stateData) : base(etity, stateMachine, animGBooName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
        isPPlayerInMaxAgroRange = entity.CheckPlayerInMaxAgroRange();
        isGrounded = entity.CheckGround();

    }

    public override void Enter()
    {
        base.Enter();
        isDodgeOver = false;

        entity.SetVelocity(stateData.dodgeSpeed, stateData.dodgeAngle, -entity.facingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if(Time.time >= startTime + stateData.dodgeTime && isGrounded)
        {
            isDodgeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}