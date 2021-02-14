using UnityEngine;
using UnityEditor;

public sealed class TrySkillActivate : Node
{
    private BaseAIModule ai;
    private CharacterStats self;
    private CharacterStats target;
    private BaseSkill skill;

    public TrySkillActivate(BaseAIModule ai, CharacterStats self, CharacterStats target, BaseSkill skill)
    {
        this.ai = ai;
        this.self = self;
        this.target = target;
        this.skill = skill;
    }

    public override NodeState Evaluate()
    {
        return skill.activate(self, target) ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
