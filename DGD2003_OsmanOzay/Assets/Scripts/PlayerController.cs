using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public Transform playerCamera;
    public float mouseSensitivity = 15f;
    public float moveSpeed = 5f;

    private float xRotation = 0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Keyboard.current == null || Mouse.current == null) return;

        float mouseX = Mouse.current.delta.x.ReadValue() * mouseSensitivity * Time.deltaTime;
        float mouseY = Mouse.current.delta.y.ReadValue() * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        if (playerCamera != null)
        {
            playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

        transform.Rotate(Vector3.up * mouseX);

        float h = 0;
        float v = 0;

        if (Keyboard.current.wKey.isPressed) v = 1;
        if (Keyboard.current.sKey.isPressed) v = -1;
        if (Keyboard.current.aKey.isPressed) h = -1;
        if (Keyboard.current.dKey.isPressed) h = 1;

        if (Keyboard.current.digit4Key.wasPressedThisFrame)
        {
            ResetAllBools();
            animator.SetBool("isDancing", true);
        }

        if (Keyboard.current.digit5Key.wasPressedThisFrame)
        {
            ResetAllBools();
            animator.SetBool("isHappy", true);
        }

        if (Keyboard.current.digit6Key.wasPressedThisFrame)
        {
            ResetAllBools();
            animator.SetBool("isSad", true);
        }

        if (h != 0 || v != 0)
        {
            ResetAllBools();
        }

        float move_amount = Mathf.Clamp01(new Vector2(h, v).magnitude);
        animator.SetFloat("MoveAmount", move_amount, 0.1f, Time.deltaTime);

        Vector3 moveDirection = (transform.right * h + transform.forward * v).normalized;
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void ResetAllBools()
    {
        animator.SetBool("isDancing", false);
        animator.SetBool("isHappy", false);
        animator.SetBool("isSad", false);
    }
}