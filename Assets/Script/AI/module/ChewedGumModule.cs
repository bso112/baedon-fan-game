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

    public override void constructBehaviourTree(CharacterStats target, CharacterStats self, float recogRange)
    {

        Node tryManaShieldActivate = new TrySkillActivate(this, self, skills["ManaShield"]);

        Node isEnemyClose = new IsEnemyClose(self.transform.position, target.transform.position, recogRange);
        Node activateClosedSkill = new ActivateSkills(target, new List<BaseSkill> { skills["Explosion"], skills["FireBlast"] }, 1F);
        Node tryClosedAttack = new Sequence(new List<Node>{ isEnemyClose, activateClosedSkill });

        Node activateRangedSkill = new ActivateSkills (target,new List<BaseSkill> { skills["IceAge"], skills["Thunder"] },3F);

        Node FightNode = new Selector(new List<Node> { tryManaShieldActivate, tryClosedAttack, activateRangedSkill });
        topNode = new Selector(new List<Node> { FightNode  });

    }

}
