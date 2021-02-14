using System.Collections;
using UnityEngine;
using UnityEditor;
public class Explosion : BaseSkill
{
   public Explosion()
   : base(6F)
    {
        damage = 15F;
    }




    public override string getName()
    {
        return "Explosion";
    }

    protected override IEnumerator onActivate(CharacterStats self, CharacterStats target)
    {
        if (self == null || target == null)
            yield break;

        GameObject explosion = GameObject.Instantiate(Resources.Load("Prefabs/Explosion"), self.transform.position + new Vector3(0, 1F), Quaternion.identity) as GameObject;

        HurtOnTouch hurt = explosion.GetComponent<HurtOnTouch>();
        hurt.except = self;
        hurt.damageOnTouchEnter = damage;
    }

    protected override void onInactivate(CharacterStats self, CharacterStats target)
    {

    }
}
