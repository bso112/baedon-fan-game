using System;
using UnityEngine;
using ExtensionMethods;




[RequireComponent(typeof(CharacterStats))]
public class AIController : MonoBehaviour
{
    public AI_MODULE_TYPE moduleType;
    public CharacterStats target;
    public CharacterStats self;
    //여기 범위까지는 근접공격
    public float closeAttackRange = 0F;

    //배틀에 진입하는 조건을 외부에서 설정해준다.
    public bool inBattle = false;


    private BaseAIModule aiModule;


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, closeAttackRange);
    }


    // Start is called before the first frame update
    void Start()
    {
        aiModule = createAIModule();
        self = GetComponent<CharacterStats>();
        aiModule.constructBehaviourTree(target, self, closeAttackRange);

    }

    // Update is called once per frame
    void Update()
    {
        aiModule.update();
    }



    private BaseAIModule createAIModule()
    {
        switch (moduleType)
        {
            case AI_MODULE_TYPE.CHEWEDGUM:
                return new ChewedGumModule();

        }

        throw new Exception("Invaild AIModule");
    }


}
