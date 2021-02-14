using UnityEngine;
public class Interval : Node
{
    private float timeStamp = 0;
    private float interval = 0;

    public Interval(float interval)
    {
        this.interval = interval;
    }

    public override NodeState Evaluate()
    {
        NodeState state = Time.time > timeStamp + interval ? NodeState.SUCCESS : NodeState.FAILURE;
        if(state == NodeState.SUCCESS)
            timeStamp = Time.time;
        
        return state;
    }
}
