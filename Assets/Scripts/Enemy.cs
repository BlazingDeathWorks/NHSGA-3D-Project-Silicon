using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private float hitFlashTime = 0.2f;
    private Transform destination;
    private NavMeshAgent agent;
    private Material originalMaterial;
    private MeshRenderer meshRenderer;

    

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    // Update is called once per frame
    void Update()
    { 
        if (destination == null) return;

        agent.SetDestination(destination.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerHealth playerHealth))
        {
            StartCoroutine("HitFlash");
            playerHealth.TakeDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            agent.isStopped = false;
            destination = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            destination = null;
            agent.isStopped = true;
        }
    }

    private IEnumerator HitFlash()
    {
        meshRenderer.material = flashMaterial;
        yield return new WaitForSecondsRealtime(hitFlashTime);
        meshRenderer.material = originalMaterial;
    }
}
