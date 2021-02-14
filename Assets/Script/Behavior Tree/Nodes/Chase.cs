using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public sealed class Chase : Node
{
    private Transform target;
    private NavMeshAgent agent;
    private float stopDistance;


    public Chase(Transform target, NavMeshAgent agent, float stopDistance)
    {
        this.target = target;
        this.agent = agent;
        this.stopDistance = stopDistance;

    }

    public override NodeState Evaluate()
    {
        float distance = Vector3.Distance(target.position, agent.transform.position);
        if (distance > stopDistance)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
            //쫒아가고 있다.
            return NodeState.RUNNING;
        }
        else
        {
            agent.isStopped = true;
            //도착했다.
            return NodeState.SUCCESS;
        }
    }


}