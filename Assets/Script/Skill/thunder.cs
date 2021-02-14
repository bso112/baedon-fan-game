using System.Collections;
using UnityEngine;

public class Thunder : BaseSkill
{

    public Thunder()
    : base(30F)
    {

    }


    public override string getName()
    {
        return "Thunder";
    }

    protected override IEnumerator onActivate(CharacterStats self, CharacterStats target)
    {
        if (self == null || target == null)
            yield break;

        GameObject toInstantiate = Resources.Load("Prefabs/Thunder") as GameObject;
        GameObject.Instantiate(toInstantiate, target.transform.position + new Vector3(0, 20F, 0), toInstantiate.transform.rotation);
    }

    protected override void onInactivate(CharacterStats self, CharacterStats target)
    {

    }
}
