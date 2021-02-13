using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class IceAge : BaseSkill
{
    private int numOfIce = 3;
    private float randomWeight = 3;

    public IceAge(int numberOfIce, float randomWeight)
   : base(1F)
    {
        this.numOfIce = numberOfIce;
        this.randomWeight = randomWeight;
    }

    public override string getName()
    {
        return "IceAge";
    }

    //코루틴으로 만들어야함.
    protected override IEnumerator onActivate(CharacterStats target)
    {
        Transform transform = target.GetComponent<Transform>();
        List<Vector3> positions = new List<Vector3>();

        for (int i = 0; i < numOfIce; ++i)
        {
            Vector3 position = transform.position + new Vector3(Random.Range(-randomWeight, randomWeight), 0, Random.Range(-randomWeight, randomWeight));
            positions.Add(position);
            visualizeDangerArea(position);
        }
        yield return new WaitForSeconds(1F);

        for(int i =0; i< numOfIce; ++i) 
            GameObject.Instantiate(Resources.Load("Prefabs/Crystal"), positions[i], Quaternion.identity);
    }

    protected override void onInactivate(CharacterStats target)
    {

    }
}
