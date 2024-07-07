using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float range = 15f;
    Transform target;


    // Update is called once per frame
    void Update()
    {
        FindClosesTarget();
        Aimeapon();
    }

    void FindClosesTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closesTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

            if (targetDistance < maxDistance)
            {
                closesTarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }

        target = closesTarget;
    }

    void Aimeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        transform.LookAt(target);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }

    }

    void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        emissionModule.enabled = isActive;
    }
}
