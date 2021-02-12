﻿using UnityEngine;
using System.Collections.Generic;
using System;
using ExtensionMethods;

public class ChewedGumModule : BaseModule
{
  
   
    public ChewedGumModule()
    {
        addSkill(new ManaShield());
        addSkill(new Explosion());
        addSkill(new FireBlast());
        addSkill(new IceAge());
        addSkill(new Thunder());
        
    }

    public override void chase(CharacterStats target, CharacterStats self)
    {
        
    }

    public override void fight(CharacterStats target, CharacterStats self)
    {

        activateSkill("ManaShield", self);
        activateSkill("Thunder", target);

    }

    public override void idle()
    {
     
    }


    protected override bool isSkillCanActivate(ISkill skill)
    {
        bool result = false;
        skill.ifNotNull(it =>
        {
            switch (skill.getName())
            {
                case "ManaShield":
                    result = true;
                    break;
                case "Thunder":
                    result = true;
                    break;
            }
        });


        return result;
    }
}