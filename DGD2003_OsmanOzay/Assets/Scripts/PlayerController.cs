using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    public Transform playerCamera;

    public float walkSpeed = 4f;
    public float sprintSpeed = 8f;
    public float jumpHeight = 1.5f;
    public float gravity = -19.62f;
    public float turnSmoothTime = 0.15f;
    public float interactionDistance = 5f;
    public LayerMask paperLayer;

    private float turnSmoothVelocity;
    private float velocityY;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        if (controller.isGrounded && velocityY < 0)
        {
            velocityY = -2f;
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        float h = 0; float v = 0;
        if (Keyboard.current.wKey.isPressed) v = 1;
        if (Keyboard.current.sKey.isPressed) v = -1;
        if (Keyboard.current.aKey.isPressed) h = -1;
        if (Keyboard.current.dKey.isPressed) h = 1;

        bool isSprinting = Keyboard.current.leftShiftKey.isPressed;
        float currentSpeed = isSprinting ? sprintSpeed : walkSpeed;

        Vector3 direction = new Vector3(h, 0f, v).normalized;
        Vector3 finalMovement = Vector3.zero;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            finalMovement = moveDir.normalized * currentSpeed;
        }

        if (Keyboard.current.spaceKey.wasPressedThisFrame && controller.isGrounded)
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
            animator.SetTrigger("Jump");
        }

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interact();
        }

        velocityY += gravity * Time.deltaTime;
        finalMovement.y = velocityY;

        controller.Move(finalMovement * Time.deltaTime);

        float targetMoveAmount = 0f;
        if (direction.magnitude > 0)
        {
            targetMoveAmount = isSprinting ? 1f : 0.5f;
        }
        animator.SetFloat("MoveAmount", targetMoveAmount, 0.1f, Time.deltaTime);
    }

    void Interact()
    {
        Debug.DrawRay(playerCamera.position, playerCamera.forward * interactionDistance, Color.red, 2f);

        if (Physics.Raycast(playerCamera.position, playerCamera.forward, out RaycastHit hit, interactionDistance))
        {
            Debug.Log("Hit: " + hit.collider.name + " | Layer: " + LayerMask.LayerToName(hit.collider.gameObject.layer));

            if ((paperLayer.value & (1 << hit.collider.gameObject.layer)) > 0)
            {
                Destroy(hit.collider.gameObject);
            }
        }
        else
        {
            Debug.Log("No hit");
        }
    }
}