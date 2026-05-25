using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public TextMeshProUGUI sayacYazisi;
    public float interactDistance = 5f;

    private int totalNotes = 0;
    private int collectedNotes = 0;

    void Start()
    {
        totalNotes = FindObjectsOfType<LectureNote>().Length;

        if (sayacYazisi != null)
        {
            sayacYazisi.text = "Collected Notes: 0 / " + totalNotes;
        }
    }

    void Update()
    {
        if (Keyboard.current != null && Keyboard.current.rKey.wasPressedThisFrame)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, interactDistance))
            {
                if (hit.collider.GetComponent<LectureNote>() != null)
                {
                    Destroy(hit.collider.gameObject);
                    collectedNotes++;

                    if (sayacYazisi != null)
                    {
                        if (collectedNotes >= totalNotes)
                            sayacYazisi.text = "CONGRATULATIONS! You collected all the notes!";
                        else
                            sayacYazisi.text = "Collected Notes: " + collectedNotes + " / " + totalNotes;
                    }
                }
            }
        }
    }
}