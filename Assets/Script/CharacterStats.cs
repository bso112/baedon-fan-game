using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animator))]
public class CharacterStats : MonoBehaviour
{
    [SerializeField]
    FloatStat hp;
    [SerializeField]
    FloatStat mp;
    Animator animator;

    private bool isManaBarriered = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
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
        {
            hp -= amount;
            animator.SetTrigger("hit");
        }
    }
   
}
