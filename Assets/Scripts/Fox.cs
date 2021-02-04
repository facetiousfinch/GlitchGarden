using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject other = otherCollider.gameObject;

        if (other.GetComponent<Defender>())
        {
            if (other.GetComponent<Gravestone>())
            {
                animator.SetBool("jumpTrigger", true);
            }
            else
            {
                GetComponent<Attacker>().Attack(other);
            }
        }
    }
}
