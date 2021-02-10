using UnityEngine;
using System.Collections.Generic;
using System;

public class ChewedGumModule : BaseModule
{
   
    public ChewedGumModule()
    {
        addSkill(new ManaShield());
        addSkill(new Explosion());
        addSkill(new FireBlast());
        addSkill(new IceAge());
        
    }

    public override void chase(CharacterStats target, CharacterStats self)
    {
        
    }

    public override void fight(CharacterStats target, CharacterStats self)
    {
        activateSkill("ManaShield", self);

    }

    public override void idle()
    {
     
    }


    protected override bool isSkillCanActivate(ISkill skill)
    {
        if (null == skill)
        {
            Debug.LogWarning("skill is null");
            return false;
        }


        switch (skill.getName())
        {
            case "ManaShield":
                return true;
        }

        return false;
    }
}
