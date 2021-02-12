using ExtensionMethods;
using System;
using UnityEngine;
using System.Collections;


public abstract class BaseSkill : ISkill
{
    //스킬의 대상
    private CharacterStats target;
    //쿨타임 (지속시간 포함)
    private readonly float cooldown;
    //지속시간
    private readonly float duration;
    //스킬을 사용한 시점
    private float activateTimeStamp = 0F;

    //스킬범위
    protected float range = 1F;

    public abstract string getName();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cooldown">duration 이후 스킬을 쓰지 못하는 시간(초)</param>
    /// <param name="duration">스킬의 지속시간(초)</param>
    public BaseSkill(float cooldown, float duration)
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

            it.StartCoroutine(onActivate(target));

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

    //스킬 발동전 범위 보여주기
    protected void visualizeDangerArea(Vector3 position)
    {
        position.y = 0;
        GameObject area = GameObject.Instantiate(Resources.Load("Prefabs/WarnArea"), position, Quaternion.identity) as GameObject;
        area.transform.localScale = new Vector3(range, 0.1F, range);

    }

    protected abstract IEnumerator onActivate(CharacterStats target);
    protected abstract void onInactivate(CharacterStats target);


}
