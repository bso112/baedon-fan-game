using UnityEngine;
using UnityEditor;
using System.Collections;

public class Thunder : BaseSkill
{
    UnityEngine.Object thunder;

    public Thunder()
    : base(8F, 5F)
    {

    }


    public override string getName()
    {
        return "Thunder";
    }

    protected override IEnumerator onActivate(CharacterStats target)
    {
        GameObject toInstantiate = Resources.Load("ParticleSystem/Lightning") as GameObject;
        thunder = GameObject.Instantiate(toInstantiate, target.transform.position + new Vector3(0, 20F, 0), toInstantiate.transform.rotation);
        return null;
    }

    protected override void onInactivate(CharacterStats target)
    {
        if (thunder != null)
            GameObject.Destroy(thunder);
    }
}
