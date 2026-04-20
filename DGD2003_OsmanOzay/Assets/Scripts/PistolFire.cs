using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponFire : MonoBehaviour
{
    public Transform muzzlePoint;
    public ParticleSystem muzzleFlash;
    public float range = 100f;

    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame || Mouse.current.leftButton.wasPressedThisFrame)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (muzzleFlash != null)
        {
            muzzleFlash.Play();
        }

        Ray ray = new Ray(muzzlePoint.position, muzzlePoint.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, range))
        {
            Debug.Log("PEW! Laser fired and hit: " + hitInfo.transform.name);
            Debug.Log("Hit coordinates: " + hitInfo.point);
        }
        else
        {
            Debug.Log("Laser fired but missed...");
        }

        Debug.DrawRay(muzzlePoint.position, muzzlePoint.forward * range, Color.red, 1f);
    }
}