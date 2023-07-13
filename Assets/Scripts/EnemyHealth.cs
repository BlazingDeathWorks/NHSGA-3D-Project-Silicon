using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int health = 3;
    [SerializeField] private Material flashMaterial; 
    [SerializeField] private float hitFlashTime = 0.05f;
    private Rigidbody rb;
    public Material deadMaterial;
    private Material originalMaterial;
    private MeshRenderer meshRenderer;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMaterial = meshRenderer.material;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Make sure the bullet is NOT a trigger
    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Bullet")) return;
        rb.AddForce(Vector3.up * 0.5f + (transform.position-other.transform.position).normalized*1f);
        StartCoroutine("HitFlash");
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

    private IEnumerator HitFlash()
    {
        meshRenderer.material = flashMaterial;
        yield return new WaitForSecondsRealtime(hitFlashTime);
        meshRenderer.material = health>0?originalMaterial:deadMaterial;
    }
}
