using UnityEngine;
using TMPro;

public class NoteCounter : MonoBehaviour
{
    private TextMeshProUGUI counterText;
    private int totalNotes;

    void Start()
    {
        counterText = GetComponent<TextMeshProUGUI>();
        totalNotes = FindObjectsOfType<LectureNote>().Length;
    }

    void Update()
    {
        int remainingNotes = FindObjectsOfType<LectureNote>().Length;
        int collectedNotes = totalNotes - remainingNotes;

        if (collectedNotes >= totalNotes)
        {
            counterText.text = "CONGRATULATIONS! You collected all the notes!";
        }
        else
        {
            counterText.text = "Collected Notes: " + collectedNotes + " / " + totalNotes;
        }
    }
}