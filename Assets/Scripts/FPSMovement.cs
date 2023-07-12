using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FPSMovement : MonoBehaviour
{

    [SerializeField] private Animator animator;
    Keyboard kb;
    Mouse mouse;

    float xDir;
    float yDir;

    public float moveSpeed;
    public float firingSpeedMovementMulti=0.4f;
    public float mouseSensitivity;
    public float mouseYMax;
    public float mouseYMin;
    [Header("Jump")]
    public float jumpForce;
    public LayerMask groundLayer;
    private float timeBetweenJumps=0.5f;
    private float timeOfLastJump;
    [SerializeField]private float rayLength;

    [Tooltip("Set the character which this camera is meant to follow AND is a child of")]
    public Transform parentTransform;
    public Transform pivotTransform;
    public Transform gunTransform;
    [SerializeField]private Rigidbody parentRb;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnJump(InputValue inputValue)
    {
        if (!inputValue.isPressed) return;
        if (Physics.Raycast(parentTransform.position, Vector3.down, rayLength, groundLayer)&&Time.time-timeOfLastJump>timeBetweenJumps)
        {
            animator.SetTrigger("Jump");
            timeOfLastJump = Time.time;
            Debug.Log("JUMP");
            parentRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {
        kb = Keyboard.current;
        mouse = Mouse.current;

        Vector3 moveDir = Vector3.zero;

        if (kb.wKey.isPressed) moveDir += Vector3.forward;
        if (kb.sKey.isPressed) moveDir -= Vector3.forward;
        if (kb.aKey.isPressed) moveDir -= Vector3.right;
        if (kb.dKey.isPressed) moveDir += Vector3.right;
        animator.SetBool("isWalking",moveDir.magnitude > 0.5f);
        moveDir = Quaternion.AngleAxis(yDir, Vector3.up) * moveDir;
        parentRb.MovePosition(parentRb.transform.position+moveDir * moveSpeed * Time.deltaTime*(animator.GetBool("isFiring")? firingSpeedMovementMulti: 1f));

        if (kb.escapeKey.wasPressedThisFrame)
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }

        //How much has the mouse moved since the last frame?
        Vector2 mouseInput = mouse.delta.ReadValue();

        //Note that these are switched!
        xDir -= mouseInput.y * mouseSensitivity;
        yDir += mouseInput.x * mouseSensitivity;

        xDir = Mathf.Clamp(xDir, mouseYMin, mouseYMax);

        
        parentTransform.rotation = Quaternion.Euler(transform.rotation.x, yDir, transform.rotation.z);
        pivotTransform.transform.rotation = Quaternion.Euler(xDir, yDir,pivotTransform.transform.rotation.z);

        transform.LookAt(pivotTransform);
       // gunTransform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z);


    }
}