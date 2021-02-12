using UnityEngine;
using System.Collections;



public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    FloatStat hp;
    [SerializeField]
    FloatStat mp;

    private bool isManaBarriered = false;

    public void manaBarrierActivate()
    {
        isManaBarriered = true;
    }

    public void manaBarrierInactivate()
    {
        isManaBarriered = false;
    }

    public void takeDamage(float amount)
    {
        Debug.Log(gameObject.name + "got " + amount + "of damage");
        if (isManaBarriered)
            mp -= amount;
        else
            hp -= amount;
    }
   
}
