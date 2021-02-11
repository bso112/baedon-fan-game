
using UnityEngine;
using System;

public sealed class ManaShield : BaseSkill
{
    UnityEngine.Object manaShield;

    //쿨타임 정해주기
    public ManaShield()
       : base(8F, 10F)
    {

    }


    public override string getName()
    {
        return "ManaShield";
    }


    protected override void onActivate(CharacterStats target)
    {
        target.manaBarrierActivate();
        manaShield = GameObject.Instantiate(Resources.Load("Prefabs/ManaShield"), target.transform, false);
    }


    protected override void onInactivate(CharacterStats target)
    {
        target.manaBarrierInactivate();
        if(manaShield != null)
            GameObject.Destroy(manaShield);

    }

 
}
