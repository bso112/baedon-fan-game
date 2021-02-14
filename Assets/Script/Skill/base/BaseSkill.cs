using System.Collections;
using UnityEngine;


public abstract class BaseSkill
{
    protected float damage;
    //스킬의 술사
    protected CharacterStats self;
    //스킬의 대상
    protected CharacterStats target;
    //쿨타임 (지속시간 포함)
    protected readonly float cooldown;
    //지속시간
    protected readonly float duration;
    //스킬을 사용한 시점
    protected float activateTimeStamp = float.MinValue;


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
            Inactivate(self, target);
    }

    /// <summary>
    /// 쿨타임이 끝나면 스킬을 발동한다. (self와 target은 같을 수 있다)
    /// </summary>
    /// <param name="self">스킬을 발동한 사람</param>
    /// <param name="target">타깃</param>
    public bool activate(CharacterStats self, CharacterStats target)
    {
        bool result = false;

        if (target == null || self == null)
            return false;



        if (!canActivate())
            return false;

        Debug.Log("activate skill : " + getName());

        //이미 활성화 되있다면, 스킬 비활성화
        Inactivate(self, target);

        this.self = self;
        this.target = target;

     
        activateTimeStamp = Time.time;

        //스킬 활성화
        self.StartCoroutine(onActivate(self, target));

        result = true;


        return result;
    }


    public void Inactivate(CharacterStats self, CharacterStats target)
    {
        if (target == null || self == null)
            return;


        onInactivate(self, target);
        this.self = null;
        this.target = null;


    }

    protected bool canActivate()
    {
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

    protected abstract IEnumerator onActivate(CharacterStats self, CharacterStats target);
    protected abstract void onInactivate(CharacterStats self, CharacterStats target);


}
