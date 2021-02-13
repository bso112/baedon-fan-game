using UnityEngine;
using System.Collections.Generic;
using System;
using ExtensionMethods;

public class ChewedGumModule : BaseAIModule
{

    public ChewedGumModule()
    {
        addSkill(new ManaShield());
        addSkill(new Explosion());
        addSkill(new FireBlast());
        addSkill(new IceAge(3, 3));
        addSkill(new Thunder());
        
    }

    public override void constructBehaviourTree(CharacterStats target)
    {

        Node n = new TryManaShieldActivate(this, target);
        topNode = new Selector(new List<Node> { n });

    }



    protected override bool isSkillCanActivate(BaseSkill skill)
    {
        return true;
    }
}
