using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;
    public Transform playerCamera;

    public float moveSpeed = 5f;
    public float turnSmoothTime = 0.4f;
    private float turnSmoothVelocity;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        float h = 0; float v = 0;
        if (Keyboard.current.wKey.isPressed) v = 1;
        if (Keyboard.current.sKey.isPressed) v = -1;
        if (Keyboard.current.aKey.isPressed) h = -1;
        if (Keyboard.current.dKey.isPressed) h = 1;

        if (Keyboard.current.digit4Key.wasPressedThisFrame) { ResetAllBools(); animator.SetBool("isDancing", true); }
        if (Keyboard.current.digit5Key.wasPressedThisFrame) { ResetAllBools(); animator.SetBool("isHappy", true); }
        if (Keyboard.current.digit6Key.wasPressedThisFrame) { ResetAllBools(); animator.SetBool("isSad", true); }
        if (h != 0 || v != 0) { ResetAllBools(); }

        Vector3 direction = new Vector3(h, 0f, v).normalized;

        if (direction.magnitude >= 0.1f)
        {
            // Karakterin ayaklarýný gidilen yöne doðru yumuþakça döndür
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Fiziksel çarpýþmalarý hesaplayarak (duvarlardan geçmeden) ilerle
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
        }

        // Yerçekimi (Havada kalmamasý için)
        controller.Move(new Vector3(0, -9.81f, 0) * Time.deltaTime);

        float move_amount = Mathf.Clamp01(direction.magnitude);
        animator.SetFloat("MoveAmount", move_amount, 0.1f, Time.deltaTime);
    }

    void ResetAllBools()
    {
        animator.SetBool("isDancing", false);
        animator.SetBool("isHappy", false);
        animator.SetBool("isSad", false);
    }
}