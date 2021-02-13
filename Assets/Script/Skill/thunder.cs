using System.Collections;
using UnityEngine;

public class Thunder : BaseSkill
{

    public Thunder()
    : base(2F)
    {

    }


    public override string getName()
    {
        return "Thunder";
    }

    protected override IEnumerator onActivate(CharacterStats target)
    {
        GameObject toInstantiate = Resources.Load("Prefabs/Thunder") as GameObject;
        GameObject.Instantiate(toInstantiate, target.transform.position + new Vector3(0, 20F, 0), toInstantiate.transform.rotation);
        yield return null;
    }

    protected override void onInactivate(CharacterStats target)
    {

    }
}
