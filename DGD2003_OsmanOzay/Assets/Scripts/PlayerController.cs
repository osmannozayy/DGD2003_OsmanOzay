using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    public float rotationSpeed = 15f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Keyboard.current == null) return;

        float h = 0;
        float v = 0;

        if (Keyboard.current.wKey.isPressed) v = 1;
        if (Keyboard.current.sKey.isPressed) v = -1;
        if (Keyboard.current.aKey.isPressed) h = -1;
        if (Keyboard.current.dKey.isPressed) h = 1;

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
        {
            ResetAllBools();
            animator.SetBool("isDancing", true);
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
        {
            ResetAllBools();
            animator.SetBool("isHappy", true);
        }

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
        {
            ResetAllBools();
            animator.SetBool("isSad", true);
        }

        if (h != 0 || v != 0)
        {
            ResetAllBools();
        }

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;
        forward.Normalize();
        right.Normalize();

        Vector3 moveDir = (forward * v + right * h).normalized;
        float move_amount = Mathf.Clamp01(moveDir.magnitude);

        animator.SetFloat("MoveAmount", move_amount, 0.1f, Time.deltaTime);

        if (moveDir != Vector3.zero)
        {
            Quaternion targetRot = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
        }
    }

    void ResetAllBools()
    {
        animator.SetBool("isDancing", false);
        animator.SetBool("isHappy", false);
        animator.SetBool("isSad", false);
    }
}