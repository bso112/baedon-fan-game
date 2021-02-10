
using UnityEngine;
using System;

public class ManaShield : BaseSkill
{

    public override void activate(CharacterStats target)
    {
        target.ManaBarrierActivate();
        GameObject.Instantiate(Resources.Load("Prefabs/ManaShield"), target.transform, false);
    }

    public override string getName()
    {
        return "ManaShield";
    }

    public override void inactivate(CharacterStats target)
    {
        target.ManaBarrierInactivate();
    }

 
}
