using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State 
{
    protected FiniteStateMachine stateMachine;
    protected Entity entity;
    protected Core core;


    public float startTime {  get; protected set; }

    protected string animGBooName;

    public State(Entity etity, FiniteStateMachine stateMachine, string animGBooName)
    {
        this.entity = etity;
        this.stateMachine = stateMachine;
        this.animGBooName = animGBooName;
        core = entity.Core;
    }

    public virtual void Enter()
    {
        startTime = Time.time;
        entity.anim.SetBool(animGBooName, true);
        DoChecks();
    }

    public virtual void Exit() 
    {
        entity.anim.SetBool(animGBooName, false);
    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }
}
