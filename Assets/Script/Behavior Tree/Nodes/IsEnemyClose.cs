using UnityEngine;

public sealed class IsEnemyClose : Node
{
    public Transform origin;
    public Transform target;
    public float range;

    public IsEnemyClose(Transform origin, Transform target, float range)
    {
        this.origin = origin;
        this.target = target;
        this.range = range;
    }

    public override NodeState Evaluate()
    {
        if (target == null)
            return NodeState.FAILURE;


        if (range == 0)
        {
            Debug.LogWarning("range is 0");
            return NodeState.FAILURE;
        }

        return (target.position - origin.position).magnitude <= range ? NodeState.SUCCESS : NodeState.FAILURE;



    }
}
