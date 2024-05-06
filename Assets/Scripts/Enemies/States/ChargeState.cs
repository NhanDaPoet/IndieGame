using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeState : State
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }
    private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

    private Movement movement;
    private CollisionSenses collisionSenses;

    protected D_ChargeState stateData;

    protected bool isPlayerInMinAgroRange;
    protected bool isDetectingWall;
    protected bool isDetectingLedge;
    protected bool isChargeTimeOver;
    protected bool performCloseRangeAction;

    public ChargeState(Entity etity, FiniteStateMachine stateMachine, string animGBooName, D_ChargeState stateData) : base(etity, stateMachine, animGBooName)
    {
        this.stateData = stateData;
    }

    public override void DoChecks()
    {
        base.DoChecks();

        isPlayerInMinAgroRange = entity.CheckPlayerInMinAgroRange();
        isDetectingWall = CollisionSenses.WallFront;
        isDetectingLedge = CollisionSenses.LedgeVertical;

        performCloseRangeAction = entity.CheckPlayerInCloseRangeAction();
    }

    public override void Enter()
    {
        base.Enter();
        isChargeTimeOver = false;

        Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Movement?.SetVelocityX(stateData.chargeSpeed * Movement.FacingDirection);

        if (Time.time >= startTime + stateData.chargeTime)
        {
            isChargeTimeOver = true;
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
