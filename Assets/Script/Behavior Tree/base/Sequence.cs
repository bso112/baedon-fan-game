using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Node
{
    protected List<Node> nodes = new List<Node>();

    public Sequence(List<Node> nodes)
    {
        this.nodes = nodes;
    }
    public override NodeState Evaluate()
    {
        nodeState = NodeState.SUCCESS;

        foreach (var node in nodes)
        {
            NodeState state = node.Evaluate();
            if (state == NodeState.FAILURE)
            {
                nodeState = state;
                return nodeState;
            }

            //하나라도 running이면 running 이다.
            if (state == NodeState.RUNNING)
                nodeState = state;
        }
        
        return nodeState;
    }
}