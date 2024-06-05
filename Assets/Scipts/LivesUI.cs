using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    public PauseManager state;
    public GameObject gameOver;

    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " Lives";
        
        if (PlayerStats.Lives <= 0){
            state.Pause();
            gameOver.SetActive(true);
        }
    }
}
