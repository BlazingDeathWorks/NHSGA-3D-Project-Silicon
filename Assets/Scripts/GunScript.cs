using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunScript : MonoBehaviour
{
    [SerializeField] private LayerMask enemyLayerMask;
    public float maxRayCastDistance;
    [SerializeField] private GameObject visualEffect;
    [SerializeField] private Animator animator;
    public void OnFire(InputValue inputValue)
    {
        //Deprecated for particle collision
        /*Mouse mouse = Mouse.current;
        Ray cameraRay = Camera.main.ScreenPointToRay(mouse.position.ReadValue());
        RaycastHit hit;
        Debug.DrawRay(cameraRay.origin, cameraRay.direction);
        if (Physics.Raycast(cameraRay, out hit, maxRayCastDistance,enemyLayerMask))
        {
            if (hit.collider != null) { Destroy(hit.collider.gameObject); }
        }*/
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        visualEffect.SetActive(Mouse.current.leftButton.isPressed);
        animator.SetBool("isFiring", Mouse.current.leftButton.isPressed);
    }
}
