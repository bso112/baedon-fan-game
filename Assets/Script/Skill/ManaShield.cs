
using UnityEngine;
using System.Collections;

public sealed class ManaShield : BaseSkill
{
    GameObject manaShield;

    //쿨타임 정해주기
    public ManaShield()
       : base(10F, 20F)
    {

    }


    public override string getName()
    {
        return "ManaShield";
    }


    protected override IEnumerator  onActivate(CharacterStats self, CharacterStats target)
    {
        if (self == null || target == null)
            yield break;


        self.GetComponent<Animator>().Play("mana_shield");

        yield return new WaitForSeconds(0.5F);

        target.manaBarrierActivate();
        manaShield = GameObject.Instantiate(Resources.Load("Prefabs/ManaShield"), target.transform, false) as GameObject;
        manaShield.transform.localPosition = new Vector3(0F, 2.2F);
        
    }


    protected override void onInactivate(CharacterStats self, CharacterStats target)
    {
        if (self == null || target == null)
            return;

        target.manaBarrierInactivate();
        if(manaShield != null)
            GameObject.Destroy(manaShield);

    }

 
}
