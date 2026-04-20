using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class EyeOfSauron : MonoBehaviour
{
    public UnityEvent onEyeSpotted;

    void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current.gKey.wasPressedThisFrame)
        {
            onEyeSpotted.Invoke();
        }
    }
}