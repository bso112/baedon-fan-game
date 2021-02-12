using UnityEngine;
using UnityEditor;

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

    protected override void onActivate(CharacterStats target)
    {
        GameObject toInstantiate = Resources.Load("ParticleSystem/Thunder") as GameObject;
        thunder = GameObject.Instantiate(toInstantiate, target.transform.position + new Vector3(0, 20F, 0), toInstantiate.transform.rotation);
    }

    protected override void onInactivate(CharacterStats target)
    {
        if (thunder != null)
            GameObject.Destroy(thunder);
    }
}
