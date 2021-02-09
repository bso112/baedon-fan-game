using UnityEngine;
using System.Collections.Generic;


public class ShipdonkkumModule : IAIModule
{

    Dictionary<string, Skill> skills = new Dictionary<string, Skill>();

    public ShipdonkkumModule()
    {
        addSkill(new ManaShield());
        addSkill(new Explosion());
        addSkill(new FireBlast());
        addSkill(new IceAge());
        
    }


    public void idle()
    {
        
    }


    public void chase(CharacterStats target)
    {
        if (target == null) return;

    }


    public void fight(CharacterStats target)
    {
        if (target == null) return;

        activateSkill("ManaShield", target);



    }

    public void update()
    {

    }
    


    private void activateSkill(string skill, CharacterStats target)
    {
        if (isSkillCanActivate(skills[skill]))
            skills[skill].activate(target);
    }


    private bool isSkillCanActivate(Skill skill)
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

    private void addSkill(Skill skill)
    {
        skills.Add(skill.getName(), skill);
    }
}
