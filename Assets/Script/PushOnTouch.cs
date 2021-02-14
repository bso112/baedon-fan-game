using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PushOnTouch : MonoBehaviour
{
    public float force = 1F;
    public float forceDuration = 1F;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerCon = other.GetComponent<PlayerController>();
        if (playerCon)
        {
            StartCoroutine(
                playerCon.knockback((other.transform.position - gameObject.transform.position).normalized, force, forceDuration )
                );
        }
    }
}
