using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class CharacterControllerMovement : MonoBehaviour
{

    private CharacterController characterController;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundMask;

    private Vector3 moveRawInput;
    private Vector2 mouseRawInput;
    private float xRotation;
    private float yRotation;
    private Vector3 moveVelocity;

    private float yAxisVelocity;
    private bool isGrounded;

    [SerializeField] private float mouseSensitivity, mouseYMax, mouseYMin;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float gravity = -9.8f;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();  
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void OnLook(InputValue value)
    {
        mouseRawInput = value.Get<Vector2>();
        xRotation -= mouseRawInput.y * mouseSensitivity * Time.deltaTime;
        yRotation += mouseRawInput.x * mouseSensitivity * Time.deltaTime;
        //xRotation=
        //Camera.main.transform.localEulerAngles=Quaternion.Euler()
    }
    private void OnMove(InputValue value)
    {

        moveRawInput = new Vector3(value.Get<Vector2>().x, 0, value.Get<Vector2>().y);
    }
}
