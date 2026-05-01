using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 5f;
    public float sensitivity = 15f;

    private float currentX = 0f;
    private float currentY = 20f;

    void LateUpdate()
    {
        if (target == null || Mouse.current == null) return;

        currentX += Mouse.current.delta.x.ReadValue() * sensitivity * Time.deltaTime;
        currentY -= Mouse.current.delta.y.ReadValue() * sensitivity * Time.deltaTime;
        currentY = Mathf.Clamp(currentY, -10f, 60f); // Kameranýn yerin altýna girmesini engeller

        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);

        // Kamerayý Joe'nun hafif yukarýsýna ve arkasýna konumlandýr
        transform.position = target.position + new Vector3(0, 1.5f, 0) + rotation * direction;
        transform.LookAt(target.position + new Vector3(0, 1.5f, 0));
    }
}