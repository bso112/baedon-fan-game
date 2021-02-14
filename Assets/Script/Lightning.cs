using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Lightning : MonoBehaviour
{

    public float range;
    public float damage;
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
                GameObject.Instantiate(effectOnCollide, collision.intersection, Quaternion.identity);

            Collider[] colliders = Physics.OverlapSphere(collision.intersection, range);

            foreach (var collider in colliders)
            {
                CharacterStats stats = collider.GetComponent<CharacterStats>();
                if (stats)
                {
                    stats.takeDamage(damage);
                }
            }
        }

    }
}
