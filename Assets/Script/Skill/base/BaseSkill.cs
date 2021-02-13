﻿using ExtensionMethods;
using System;
using UnityEngine;
using System.Collections;


public abstract class BaseSkill
{
    //스킬의 대상
    protected CharacterStats target;
    //쿨타임 (지속시간 포함)
    protected readonly float cooldown;
    //지속시간
    protected readonly float duration;
    //스킬을 사용한 시점
    protected float activateTimeStamp = 0F;

    public abstract string getName();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cooldown">duration 이후 스킬을 쓰지 못하는 시간(초)</param>
    /// <param name="duration">스킬의 지속시간(초)</param>
    public BaseSkill(float cooldown, float duration = 0)
    {
        this.cooldown = cooldown + duration;
        this.duration = duration;
    }

    public void update()
    {

        if (isDurationOver() && target != null)
            Inactivate(target);
    }

    /// <summary>
    /// 쿨타임이 끝나면 스킬을 발동한다.
    /// </summary>
    /// <param name="target"></param>
    public bool activate(CharacterStats target)
    {
        bool result = false;

        target.ifNotNull(it =>
        {

            if (!canActivate())
                return;

            Debug.Log("activate skill : " + getName());

            //이미 활성화 되있다면, 스킬 비활성화
            Inactivate(target);

            //타겟 설정
            this.target = it;
            //canActivate 조건에서 Time.time이 0이면 안됨.
            activateTimeStamp = Time.time == 0 ? 0.1F : Time.time;

            //스킬 활성화
            it.StartCoroutine(onActivate(target));

            result = true;
        });

        return result;
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

    /// <summary>
    /// 스킬 발동 전 범위 보여주기
    /// </summary>
    /// <param name="position">스킬 발동 위치</param>
    /// <param name="range">스킬 범위</param>
    protected void visualizeDangerArea(Vector3 position, float range)
    {
        position.y = 0;
        GameObject area = GameObject.Instantiate(Resources.Load("Prefabs/WarnArea"), position, Quaternion.identity) as GameObject;
        area.transform.localScale = new Vector3(range, 0.1F, range);

    }

    protected abstract IEnumerator onActivate(CharacterStats target);
    protected abstract void onInactivate(CharacterStats target);


}
