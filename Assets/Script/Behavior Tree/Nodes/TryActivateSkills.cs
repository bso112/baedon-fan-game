using System.Collections.Generic;
using UnityEngine;
public sealed class TryActivateSkills : Node
{
    private CharacterStats target;
    private CharacterStats self;
    private List<BaseSkill> skills;
    private float lastTimeActivated;
    private float spaceBtwSkill;

    public TryActivateSkills(CharacterStats self, CharacterStats target, List<BaseSkill> skills, float spaceBtwSkill)
    {
        this.self = self;
        this.target = target;
        this.skills = skills;
        this.spaceBtwSkill = spaceBtwSkill;
    }

    public override NodeState Evaluate()
    {

        if (Time.time < lastTimeActivated + spaceBtwSkill)
        {
            //스킬 딜레이를 대기중이다.
            if (Time.time > spaceBtwSkill)
                return NodeState.FAILURE;
        }


        foreach (var skill in skills)
        {
            if (skill.activate(self, target))
            {
                lastTimeActivated = Time.time;
                return NodeState.SUCCESS;
            }
        }

        //모든 스킬이 쿨타임이다.
        return NodeState.FAILURE;
    }
}
