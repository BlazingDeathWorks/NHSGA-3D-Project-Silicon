using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 3;
    private Rigidbody rb;
    public Material deadMaterial;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //Make sure the bullet is NOT a trigger
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Bullet")) return;
        rb.AddForce(Vector3.up * 0.5f + (transform.position-other.transform.position).normalized*1f);
        health--;
        if (health == 0)
        {
            GetComponent<MeshRenderer>().material = deadMaterial;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Enemy>().enabled = false;
            enabled = false;
        }
    }
}
