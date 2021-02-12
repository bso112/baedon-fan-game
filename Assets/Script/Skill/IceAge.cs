using UnityEngine;
using System.Collections;
public class IceAge : BaseSkill
{

    public IceAge()
   : base(8F, 5F)
    {

    }

    public override string getName()
    {
        return "IceAge";
    }

    //코루틴으로 만들어야함.
    protected override IEnumerator onActivate(CharacterStats target)
    {
        Transform transform = target.GetComponent<Transform>();
        visualizeDangerArea(target.transform.position);
        Vector3 targetPosition = transform.position;
        yield return new WaitForSeconds(1F);
        GameObject.Instantiate(Resources.Load("Prefabs/Crystal"), targetPosition, Quaternion.identity);
    }

    protected override void onInactivate(CharacterStats target)
    {

    }
}
