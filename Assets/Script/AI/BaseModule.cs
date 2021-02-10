using UnityEngine;
using System.Collections.Generic;
using System;
[Serializable]
public abstract class BaseModule : IAIModule
{
    protected Dictionary<string, ISkill> skills = new Dictionary<string, ISkill>();

    public abstract void chase(CharacterStats target, CharacterStats self);
    public abstract void fight(CharacterStats target, CharacterStats self);
    public abstract void idle();
    public abstract void update();
    protected abstract bool isSkillCanActivate(ISkill skill);


    protected void addSkill(ISkill skill)
    {
        skills.Add(skill.getName(), skill);
    }

    protected void activateSkill(string skill, CharacterStats target)
    {
        if (isSkillCanActivate(skills[skill]))
            skills[skill].activate(target);
    }


}
