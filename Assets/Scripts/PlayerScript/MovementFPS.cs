using UnityEngine;
using UnityEngine.InputSystem;

public class MovementFPS : MonoBehaviour
{
    private CharacterController controller;
    private Vector2 moveInput;
    public float speedFPS;

    private Vector3 playerVelocity;
    private bool grounded;
    public float gravity = -9.8f;
    public float jumpForce = 2f;

    public Camera cameraFPS;
    private Vector2 lookPos;
    private float xRotation = 0f;
    private float xSens = 1.5f, ySens = 1.5f;

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        Jump();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        lookPos = context.ReadValue<Vector2>();
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        grounded = controller.isGrounded;
        MovePlayerFPS();
        PlayerLook();
    }

    public void MovePlayerFPS()
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = moveInput.x;
        moveDirection.z = moveInput.y;
        controller.Move(transform.TransformDirection(moveDirection * speedFPS * Time.deltaTime));

        playerVelocity.y += gravity * Time.deltaTime;
        if(grounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void Jump()
    {
        if (grounded)
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -3f * gravity);
        }
    }

    public void PlayerLook()
    {
        xRotation -= lookPos.y * ySens;
        xRotation = Mathf.Clamp(xRotation, -70f, 70f);

        cameraFPS.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * lookPos.x * xSens);
    }
    
}
