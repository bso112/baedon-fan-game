using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HurtOnTouch : MonoBehaviour
{
    public float damageOnTouchEnter = 0F;

    private void OnTriggerEnter(Collider other)
    {
        CharacterStats stats = other.gameObject.GetComponent<CharacterStats>();
        if (stats)
            stats.takeDamage(damageOnTouchEnter);


    }


}
