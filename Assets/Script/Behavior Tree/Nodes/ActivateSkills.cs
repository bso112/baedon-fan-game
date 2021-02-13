using System.Collections.Generic;
using UnityEngine;
public sealed class ActivateSkills : Node
{
    private CharacterStats target;
    private List<BaseSkill> skills;
    private float lastTimeActivated;
    private float spaceBtwSkill;

    public ActivateSkills(CharacterStats target, List<BaseSkill> skills, float spaceBtwSkill)
    {
        this.target = target;
        this.skills = skills;
        this.spaceBtwSkill = spaceBtwSkill;
    }

    public override NodeState Evaluate()
    {

        if (Time.time < lastTimeActivated + spaceBtwSkill)
        {
            if (Time.time > spaceBtwSkill)
                return NodeState.FAILURE;
        }


        foreach (var skill in skills)
        {
            if (skill.activate(target))
            {
                lastTimeActivated = Time.time;
                return NodeState.SUCCESS;
            }
        }

        return NodeState.FAILURE;
    }
}
