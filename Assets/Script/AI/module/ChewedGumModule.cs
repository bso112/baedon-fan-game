using UnityEngine;
using System.Collections.Generic;
using System;
using ExtensionMethods;

public sealed  class ChewedGumModule : BaseAIModule
{

    public ChewedGumModule()
    {
        addSkill(new ManaShield());
        addSkill(new Explosion());
        addSkill(new FireBlast());
        addSkill(new IceAge(3, 3));
        addSkill(new Thunder());
        
    }


    private new void Start()
    {
        base.Start();
        constructBehaviourTree();
    }

    private void Update()
    {
        base.update();
        animator.SetFloat("speed", navAgent.velocity.magnitude);
    }


    protected override void constructBehaviourTree()
    {
        Node tryManaShieldActivate = new TrySkillActivate(this, self, self, skills["ManaShield"]);
        Node chase = new Chase(target.transform, navAgent, 5F);
        Node isEnemyClose = new IsEnemyClose(self.transform, target.transform, closeAttackRange);
        Node activateClosedSkill = new TryActivateSkills(self, target, new List<BaseSkill> { skills["Explosion"], skills["FireBlast"] }, 1F);
        Node activateRangedSkill = new TryActivateSkills (self, target,new List<BaseSkill> { skills["IceAge"], skills["Thunder"] },3F);
        Node intervalNode = new Interval(5F);

        Node tryClosedSkill = new Sequence(new List<Node>{ isEnemyClose, activateClosedSkill });
        Node tryActivateSkill = new Selector(new List<Node> { tryManaShieldActivate, tryClosedSkill, activateRangedSkill });
        Node tryAttack = new Sequence(new List<Node> { intervalNode , tryActivateSkill });
        Node fight = new Selector(new List<Node> { tryAttack , chase});
        topNode = new Selector(new List<Node> { fight });

    }

}
