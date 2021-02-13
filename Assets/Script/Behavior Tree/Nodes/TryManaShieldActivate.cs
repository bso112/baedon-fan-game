using UnityEngine;
using UnityEditor;

public class TryManaShieldActivate : Node
{
    public BaseAIModule ai;
    public CharacterStats target;

    public TryManaShieldActivate(BaseAIModule ai, CharacterStats target)
    {
        this.ai = ai;
        this.target = target;
    }

    public override NodeState Evaluate()
    {
        return ai.activateSkill("ManaShield", target) ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
