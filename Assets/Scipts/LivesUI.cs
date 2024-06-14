using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText; 
    public PauseManager state;
    public GameObject gameOver;

    // Update is called once per frame
    void Update()
    {
        if (livesText == null || scoreText == null || state == null || gameOver == null)
        {
            Debug.LogError("One or more references are not set in the LivesUI script.");
            return;
        }

        livesText.text = PlayerStats.Lives.ToString() + " Lives";
        scoreText.text = "Score: " + PlayerStats.Score.ToString();

        if (PlayerStats.Lives <= 0)
        {
            state.Pause();
            gameOver.SetActive(true);
            SendScoreToPlayFab(); // Envoyer le score à PlayFab
        }
    }

    void SendScoreToPlayFab()
    {
        Debug.Log(PlayerStats.Score + " points envoyés à PlayFab.");
        PlayFabManager.Instance.SendScore(PlayerStats.Score);
        PlayFabManager.Instance.GetLeaderboard();
    }
}
