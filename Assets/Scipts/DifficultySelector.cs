using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DifficultySelector : MonoBehaviour
{
    public Button leftArrowButton;
    public Button rightArrowButton;
    public TextMeshProUGUI difficultyText;

    private string[] difficulties = { "Facile", "Intermédiaire", "Difficile" };
    private int currentDifficultyIndex = 0;

    void Start()
    {
        currentDifficultyIndex = GameSettings.Difficulty; 
        UpdateDifficultyText();

        rightArrowButton.onClick.AddListener(PreviousDifficulty);
        leftArrowButton.onClick.AddListener(NextDifficulty);
    }

    void UpdateDifficultyText()
    {
        difficultyText.text = difficulties[currentDifficultyIndex];
        GameSettings.Difficulty = currentDifficultyIndex;

        rightArrowButton.gameObject.SetActive(currentDifficultyIndex > 0);
        leftArrowButton.gameObject.SetActive(currentDifficultyIndex < difficulties.Length - 1);

        if (currentDifficultyIndex == 0)
        {
            leftArrowButton.gameObject.SetActive(true);
            rightArrowButton.gameObject.SetActive(false);
        }
        else if (currentDifficultyIndex == difficulties.Length - 1)
        {
            leftArrowButton.gameObject.SetActive(false);
            rightArrowButton.gameObject.SetActive(true);
        }
        else
        {
            leftArrowButton.gameObject.SetActive(true);
            rightArrowButton.gameObject.SetActive(true);
        }
    }

    void PreviousDifficulty()
    {
        if (currentDifficultyIndex > 0)
        {
            currentDifficultyIndex--;
            UpdateDifficultyText();
        }
    }

    void NextDifficulty()
    {
        if (currentDifficultyIndex < difficulties.Length - 1)
        {
            currentDifficultyIndex++;
            UpdateDifficultyText();
        }
    }
}
