using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerInteract : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI timerText;
    public float interactDistance = 5f;

    [Header("Timer & UI Screens")]
    public float timeLimit = 90f;
    public GameObject winScreen;
    public GameObject loseScreen;

    private int totalNotes = 0;
    private int collectedNotes = 0;
    private bool isGameOver = false;

    void Start()
    {
        totalNotes = FindObjectsOfType<LectureNote>().Length;

        if (winScreen != null) winScreen.SetActive(false);
        if (loseScreen != null) loseScreen.SetActive(false);

        if (counterText != null)
        {
            counterText.text = "0 / " + totalNotes;
        }
    }

    void Update()
    {
        if (isGameOver)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            return;
        }

        timeLimit -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = Mathf.Ceil(timeLimit).ToString();
        }

        if (timeLimit <= 0)
        {
            timeLimit = 0;
            LoseGame();
        }

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

                    if (counterText != null)
                    {
                        counterText.text = collectedNotes + " / " + totalNotes;
                    }

                    if (collectedNotes >= totalNotes)
                    {
                        WinGame();
                    }
                }
            }
        }
    }

    void WinGame()
    {
        isGameOver = true;
        if (winScreen != null) winScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    void LoseGame()
    {
        isGameOver = true;
        if (timerText != null) timerText.text = "0";
        if (loseScreen != null) loseScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RetryGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}