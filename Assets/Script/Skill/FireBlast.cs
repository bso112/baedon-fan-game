using System.Collections;
using UnityEngine;
public class FireBlast : BaseSkill
{

    public FireBlast()
   : base(6F)
    {
        damage = 25F;
    }



    public override string getName()
    {
        return "FireBlast";
    }

    protected override IEnumerator onActivate(CharacterStats self, CharacterStats target)
    {
        if (self == null ||  target == null)
            yield break;

        self.transform.LookAt(target.transform);

        GameObject fireblast = GameObject.Instantiate(Resources.Load("Prefabs/Fireblast"), self.transform, true) as GameObject;
        fireblast.transform.localPosition = new Vector3(0, 1F);
        fireblast.transform.localRotation = Quaternion.identity;


        HurtOnTouch hurt = fireblast.GetComponent<HurtOnTouch>();
        hurt.damageOnTouchEnter = damage;
        hurt.except = self;



    }

    protected override void onInactivate(CharacterStats self, CharacterStats target)
    {

    }
}
