using System;
using System.Collections.Generic;
[Serializable]
public abstract class BaseModule : IAIModule
{
    protected Dictionary<string, ISkill> skills = new Dictionary<string, ISkill>();

    //스킬 사이의 최소시간
    private readonly float minmumGapBtwSkill = 3F;
    private float activateSkillTimeStamp = 0F;

    public abstract void chase(CharacterStats target, CharacterStats self);
    public abstract void fight(CharacterStats target, CharacterStats self);
    public abstract void idle();



    protected abstract bool isSkillCanActivate(ISkill skill);



    protected void addSkill(ISkill skill)
    {
        skills.Add(skill.getName(), skill);
    }

    protected void activateSkill(string skill, CharacterStats target)
    {
        if (isSkillCanActivate(skills[skill]))
        {   

            skills[skill].activate(target);
        }
    }

    public void update()
    {
        foreach (var skill in skills)
        {
            skill.Value.update();
        }

    }
}
