using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime = 10f;
    private float timeSinceSpawn;
    private void OnTriggerEnter(Collider collision)
    {
        //Wall layer
        if ( collision.gameObject.layer == 3)
        {
            gameObject.SetActive(false);
        }
        //Target layer
        else if (collision.gameObject.layer == 6)
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
    [HideInInspector]
    public Vector3 movementVector;
    [SerializeField] private float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        timeSinceSpawn += Time.deltaTime;
        if (timeSinceSpawn > lifeTime)
        {
            timeSinceSpawn = 0f;
            gameObject.SetActive(false);    
        }
        transform.position += movementVector * movementSpeed * Time.deltaTime;   
    }
}
