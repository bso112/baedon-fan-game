using System;
using UnityEngine;
using ExtensionMethods;

[RequireComponent(typeof(CharacterStats))]
public class AIController : MonoBehaviour
{
    public AI_MODULE_TYPE moduleType;
    public CharacterStats target;
    public CharacterStats self;
    public float recogRange = 0F;

    //배틀에 진입하는 조건을 외부에서 설정해준다.
    public bool inBattle = false;


    private IAIModule aiModule;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, recogRange);
    }


    // Start is called before the first frame update
    void Start()
    {
        aiModule = createAIModule();
        self = GetComponent<CharacterStats>();
        inBattle = true;

    }

    // Update is called once per frame
    void Update()
    {

        if (isInBattle())
        {
            target.ifNotNull(it =>
            {
                aiModule.fight(it, self);
            });

            return;
        }


        aiModule.update();
        aiModule.idle();
    }



    private IAIModule createAIModule()
    {
        switch (moduleType)
        {
            case AI_MODULE_TYPE.CHEWEDGUM:
                return new ChewedGumModule();

        }

        throw new Exception("Invaild AIModule");
    }

    private bool isInBattle()
    {
        return inBattle && isTargetInRange(recogRange);
    }

    private bool isTargetInRange(float range)
    {
        if (range == 0)
        {
            Debug.LogWarning(name + "'s recogRange is 0");
            return false;
        }

        return (target.GetComponent<Transform>().position - GetComponent<Transform>().position).magnitude <= range;
    }
}
