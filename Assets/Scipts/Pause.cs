using UnityEngine;

public class PauseManager : MonoBehaviour
{
    //public GameObject pauseMenuUI; // Le menu des paramètres
    public bool isPaused = false;

    void Update()
    {
        // Optionnel : Permettre de mettre en pause avec la touche "Escape"
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {Resume();}
            else
            {Pause();}
        }
    }

    public void Pause()
    {
        //pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Met le jeu en pause
        isPaused = true;
    }

    public void Resume()
    {
        //pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Reprend le jeu
        isPaused = false;
    }

    public void OpenSettings()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}