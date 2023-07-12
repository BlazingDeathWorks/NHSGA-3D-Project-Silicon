using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PrefabGunScript : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public GameObject bullet;
    [Header("Pool settings")]
    GameObject[] bulletList;
    [SerializeField] private int poolSize;
    [Header("Gun Settings")]
    public float delayBetweenShots = 1f;
    private float timeOfLastShot;
    [SerializeField] private Transform gunBarrelTransform;

    private bool isFiring=false;

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
        animator.SetBool("isFiring", value.isPressed);
    }


    
    // Start is called before the first frame update
    void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        bulletList = new GameObject[poolSize];
        for (int i = 0; i < bulletList.Length; i++)
        {
            bulletList[i] = Instantiate(bullet);
            bulletList[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isFiring&&Time.time-timeOfLastShot>delayBetweenShots)
        {
            timeOfLastShot = Time.time;
            Shoot();
        }
    }

    private void Shoot()
    {
        GameObject blt = null;
        foreach(GameObject bullet in bulletList)
        {
            if (!bullet.activeInHierarchy) { blt = bullet; break; }
        }
        if (blt == null)
        {
            return;
        }
        blt.transform.position = gunBarrelTransform.position;
        blt.GetComponent<Bullet>().movementVector = Camera.main.transform.forward.normalized;
        blt.SetActive(true);
    }
}
