using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Lightning : MonoBehaviour
{
    public GameObject debugSphere;
    public float range;
    public float damage;

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
            if (debugSphere != null)
            {
                GameObject debugObj = GameObject.Instantiate(debugSphere, collision.intersection, Quaternion.identity);
                debugObj.transform.localScale = new Vector3(range, range, range);
            }

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
