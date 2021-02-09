using System;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public AI_MODULE_TYPE moduleType = AI_MODULE_TYPE.END;
    public GameObject target;
    public float recogRange = 0F;
    private AIModule aiModule;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, recogRange);
    }


    // Start is called before the first frame update
    void Start()
    {
        aiModule = createAIModule();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTargetInRange(recogRange))
        {
            if (target == null)
            {
                Debug.LogWarning(name + "'s target is null");
                return;
            }

            aiModule.fight(target);
            return;
        }

        aiModule.idle();
    }



    private AIModule createAIModule()
    {
        switch (moduleType)
        {
            case AI_MODULE_TYPE.SHIPDONKKUM:
                return new ShipdonkkumModule();

        }

        throw new Exception("Invaild AIModule");
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
