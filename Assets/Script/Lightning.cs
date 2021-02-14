using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Lightning : MonoBehaviour
{
    [HideInInspector]
    public float damage = 1F;
    [HideInInspector]
    public CharacterStats except;

    public GameObject effectOnCollide;

    private List<ParticleCollisionEvent> collisionEvents;
    private ParticleSystem ps;

    private void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
        ps = GetComponent<ParticleSystem>();
        ps.collision.SetPlane(0, GameObject.FindGameObjectWithTag("ParticlePlane")?.transform);

    }

    private void OnParticleCollision(GameObject other)
    {
        ps.GetCollisionEvents(other, collisionEvents);

        foreach (var collision in collisionEvents)
        {
            if (effectOnCollide != null)
            {
               GameObject hitBox = GameObject.Instantiate(effectOnCollide, collision.intersection, Quaternion.identity) as GameObject;
                HurtOnTouch hurt = hitBox.GetComponent<HurtOnTouch>();
                if (hurt)
                {
                    hurt.damageOnTouchEnter = damage;
                    hurt.except = except;
                }

            }
        }

    }
}
