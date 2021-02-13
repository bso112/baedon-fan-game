using UnityEngine;
using UnityEditor;

public sealed class TrySkillActivate : Node
{
    private BaseAIModule ai;
    private CharacterStats target;
    private BaseSkill skill;

    public TrySkillActivate(BaseAIModule ai, CharacterStats target, BaseSkill skill)
    {
        this.ai = ai;
        this.target = target;
        this.skill = skill;
    }

    public override NodeState Evaluate()
    {
        return skill.activate(target) ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
