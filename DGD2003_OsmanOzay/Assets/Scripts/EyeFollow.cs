using UnityEngine;

public class EyeTracker : MonoBehaviour
{
    public Transform target;
    public float trackingSpeed = 10f;
    public Vector3 rotationOffset = new Vector3(0, 0, 0);

    void Update()
    {
        if (target == null) return;

        Vector3 lookDir = target.position - transform.position;

        if (lookDir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(lookDir) * Quaternion.Euler(rotationOffset);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, trackingSpeed * Time.deltaTime);
        }
    }
}