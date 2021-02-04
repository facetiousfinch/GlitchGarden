using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{

    const string PROJECTILE_PARENT_NAME = "Projectile";

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;

    GameObject projectileParent;

    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void Update()
    {
        CheckForAttacker();
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void CheckForAttacker()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = Mathf.Abs(spawner.transform.position.y - transform.position.y)
                <= Mathf.Epsilon;

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        //todo defender should only fire if attacker is in front of him
        // if my lane spawner child count is less than or equal to 0
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }
        else return true;
    }

    public void Fire()
    {
        GameObject newProjectile = Instantiate(
            projectile,
            gun.transform.position,
            Quaternion.identity);

        newProjectile.transform.parent = projectileParent.transform;
    }
}
