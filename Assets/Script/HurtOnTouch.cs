using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

[RequireComponent(typeof(Collider))]
public class HurtOnTouch : MonoBehaviour
{
    public float damageOnTouchEnter = 0F;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("coll");
        CharacterStats stats = other.gameObject.GetComponent<CharacterStats>();
        stats.ifNotNull(it =>
        {
            it.takeDamage(damageOnTouchEnter);

        });
    }
  

}
