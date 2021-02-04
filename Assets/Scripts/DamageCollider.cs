using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCollider : MonoBehaviour
{
    LivesDisplay lives;

    private void Start()
    {
        lives = FindObjectOfType<LivesDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives.TakeLife();
        Destroy(collision.gameObject);
    }
}
