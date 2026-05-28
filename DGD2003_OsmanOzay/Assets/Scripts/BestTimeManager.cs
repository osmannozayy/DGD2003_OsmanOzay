using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BestTimeManager : MonoBehaviour
{
    public PlayerInteract playerInteract;
    public TextMeshProUGUI bestTimeText;

    void OnEnable()
    {
        if (playerInteract == null || bestTimeText == null) return;

        float currentTimeLeft = playerInteract.timeLimit;

        if (currentTimeLeft > 89f) return;

        float savedBest = PlayerPrefs.GetFloat("YeniRekor", 0f);

        if (currentTimeLeft > savedBest)
        {
            savedBest = currentTimeLeft;
            PlayerPrefs.SetFloat("YeniRekor", savedBest);
            PlayerPrefs.Save();
        }

        bestTimeText.text = "Best Time: " + (90-Mathf.Ceil(savedBest)).ToString() + "s";
    }

    public void PlayAgainFix()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}