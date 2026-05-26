using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject settingsPanelUI;

    public void OpenSettings()
    {
        if (mainMenuUI != null) mainMenuUI.SetActive(false);
        settingsPanelUI.SetActive(true);
    }

    public void CloseSettings()
    {
        if (mainMenuUI != null) mainMenuUI.SetActive(true);
        settingsPanelUI.SetActive(false);
    }

    public void ToggleMusicButton()
    {
        if (AudioManager.instance != null)
        {
            AudioManager.instance.ToggleMusic();
        }
    }
}