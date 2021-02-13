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


    public void update()
    {
        foreach (var skill in skills)
        {
            skill.Value.update();
        }

        topNode.Evaluate();
    }


    public abstract void constructBehaviourTree(CharacterStats target, CharacterStats self, float recogRange);


    protected void addSkill(BaseSkill skill)
    {
        skills.Add(skill.getName(), skill);
    }

  
}
