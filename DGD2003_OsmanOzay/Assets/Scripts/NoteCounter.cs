using UnityEngine;
using TMPro;

public class NoteCounter : MonoBehaviour
{
    private TextMeshProUGUI counterText;
    private int totalNotes;
    PlayerInteract playerInteract;
    void Start()
    {
        playerInteract = FindAnyObjectByType<PlayerInteract>();
        counterText = GetComponent<TextMeshProUGUI>();
        totalNotes = FindObjectsOfType<LectureNote>().Length;
    }

    void Update()
    {
        int remainingNotes = FindObjectsOfType<LectureNote>().Length;
        int collectedNotes = totalNotes - remainingNotes;

        counterText.text = "Collected Notes: " + collectedNotes + " / " + totalNotes;
        if (collectedNotes >= totalNotes)
        {

         playerInteract.WinGame();
        }
    }
}