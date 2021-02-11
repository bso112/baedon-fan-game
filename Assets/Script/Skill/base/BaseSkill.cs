using ExtensionMethods;
using System;
using UnityEngine;


public abstract class BaseSkill : ISkill
{
    //스킬의 대상
    private CharacterStats target;
    //쿨타임 (지속시간 포함)
    private readonly float cooldown;
    //지속시간
    private readonly float duration;

    private float activateTimeStamp = 0F;

    public abstract string getName();

    public BaseSkill(float cooldown, float duration = 0F)
    {
        this.cooldown = cooldown + duration;
        this.duration = duration;
    }

    public void update()
    {
        if (isDurationOver() && target != null)
            Inactivate(target);
    }

    public void activate(CharacterStats target)
    {
        target.ifNotNull(it =>
        {

            if (!canActivate())
                return;

            Inactivate(target);

            onActivate(it);

            this.target = it;
            //canActivate 조건에서 Time.time이 0이면 안됨.
            activateTimeStamp = Time.time == 0 ? 0.1F : Time.time;
        });
    }


    public void Inactivate(CharacterStats target)
    {
        target.ifNotNull(it =>
        {
            onInactivate(it);
            this.target = null;

        });
    }

    protected bool canActivate()
    {
        if(Time.time < cooldown && activateTimeStamp == 0)
            return true;

        return Time.time > activateTimeStamp + cooldown;
    }


    protected bool isDurationOver()
    { 
        return Time.time > activateTimeStamp + duration;
    }


    protected abstract void onActivate(CharacterStats target);
    protected abstract void onInactivate(CharacterStats target);


}
