using System;
using System.Collections.Generic;
using UnityEngine;



public enum AI_MODULE_TYPE { CHEWEDGUM, END }

[Serializable]
public abstract class BaseAIModule
{
    protected Dictionary<string, BaseSkill> skills = new Dictionary<string, BaseSkill>();
    protected Node topNode;

    //스킬 사이의 최소시간
    private readonly float minmumGapBtwSkill = 3F;
    private float activateSkillTimeStamp = 0F;


    public bool activateSkill(string skill, CharacterStats target)
    {
        if (isSkillCanActivate(skills[skill]))
        {
            skills[skill].activate(target);
            return true;
        }

        return false;
    }

    public void update()
    {
        foreach (var skill in skills)
        {
            skill.Value.update();
        }

        topNode.Evaluate();
    }


    public abstract void constructBehaviourTree(CharacterStats target);


    protected abstract bool isSkillCanActivate(BaseSkill skill);



    protected void addSkill(BaseSkill skill)
    {
        skills.Add(skill.getName(), skill);
    }

  
}
