using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject other = otherCollider.gameObject;

        if (other.GetComponent<Defender>())
        {
            GetComponent<Attacker>().Attack(other);
        }
    }
}
