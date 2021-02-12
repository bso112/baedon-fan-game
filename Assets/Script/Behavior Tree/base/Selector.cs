using System.Collections.Generic;

public class Selector : Node
{
    protected List<Node> nodes = new List<Node>();

    public Selector(List<Node> nodes)
    {
        this.nodes = nodes;
    }
    public override NodeState Evaluate()
    {
        foreach (var node in nodes)
        {
            NodeState state = node.Evaluate();

            if (state == NodeState.RUNNING || state == NodeState.SUCCESS)
            {
                nodeState = state;
                return nodeState;
            }
        }

        nodeState = NodeState.FAILURE;
        return nodeState;
    }
}