using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    [SerializeField] float health = 100f;
    [SerializeField] GameObject dealthVFX;

    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        TriggerDestroyVFX();
        Destroy(gameObject);
    }

    private void TriggerDestroyVFX()
    {
        if (dealthVFX)
        {
            var vfx = Instantiate(dealthVFX, transform.position, Quaternion.identity);
            Destroy(vfx, 1f);
        }
    }
}
