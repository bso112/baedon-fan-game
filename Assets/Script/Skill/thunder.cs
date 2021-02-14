using System.Collections;
using UnityEngine;
using ExtensionMethods;
public class Thunder : BaseSkill
{

    public Thunder()
    : base(10F, 4F)
    {
        damage = 10F;
    }


    public override string getName()
    {
        return "Thunder";
    }

    protected override IEnumerator onActivate(CharacterStats self, CharacterStats target)
    {
        if (self == null || target == null)
            yield break;


        self.GetComponent<Animator>().Play("thunder");

        yield return new WaitForSeconds(0.5F);

        GameObject effect = GameObject.Instantiate(Resources.Load("Prefabs/LightningRotateBall"), self.transform) as GameObject;
        effect.transform.localPosition = new Vector3(0F, 1F);
        effect.GetComponent<DestroySelf>().lifetime = duration - 0.5F;

        yield return new WaitForSeconds(1.0F);



        GameObject toInstantiate = Resources.Load("Prefabs/Thunder") as GameObject;
        GameObject thunder = GameObject.Instantiate(toInstantiate, target.transform.position + new Vector3(0, 20F, 0), toInstantiate.transform.rotation);
        thunder.GetComponent<DestroySelf>().ifNotNull(it => it.lifetime = duration - 1.5F);
        thunder.GetComponent<Lightning>().ifNotNull(it => { it.except = self; it.damage = damage; });
        
    }

    protected override void onInactivate(CharacterStats self, CharacterStats target)
    {

    }
}
