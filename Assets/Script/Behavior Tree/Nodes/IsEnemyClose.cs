using UnityEngine;
using UnityEditor;

public sealed class IsEnemyClose : Node
{
    public Vector3 origin;
    public Vector3 target;
    public float range;

    public IsEnemyClose(Vector3 origin, Vector3 target, float range)
    {
        this.origin = origin;
        this.target = target;
        this.range = range;
    }

    public override NodeState Evaluate()
    {
        if (range == 0)
        {
            Debug.LogWarning("range is 0");
            return NodeState.FAILURE;
        }

        return (target - origin).magnitude <= range ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
