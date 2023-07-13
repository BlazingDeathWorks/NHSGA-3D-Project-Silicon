using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 5;
    private Vector3 originalPosition;
    [SerializeField] private Slider slider;

    private void Awake()
    {
        originalPosition = transform.position;
        slider.maxValue = health;
        slider.value = health;
    }

    public void RepositionPlayer()
    {
        transform.position = originalPosition;
    }

    public void TakeDamage()
    {
        health--;
        slider.value = health;
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneController.Instance.ReloadScene();
        }
    }
}
