using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = transform.position;
    }

    public void RepositionPlayer()
    {
        transform.position = originalPosition;
    }

    public void TakeDamage()
    {
        health--;
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneController.Instance.ReloadScene();
        }
    }
}
