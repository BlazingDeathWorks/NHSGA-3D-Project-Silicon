using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;

    //Make sure the bullet is NOT a trigger
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Bullet")) return;
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
