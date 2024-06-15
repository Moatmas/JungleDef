using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapSelector : MonoBehaviour
{
    public Button leftArrowButton;
    public Button rightArrowButton;
    public TextMeshProUGUI mapText;

    private string[] maps = { "Map 1", "Map 2" };
    private int currentMapIndex = 0;

    void Start()
    {
        currentMapIndex = GameSettings.Map; 
        UpdateMapText();

        rightArrowButton.onClick.AddListener(NextMap);
        leftArrowButton.onClick.AddListener(PreviousMap);
    }

    void UpdateMapText()
    {
        mapText.text = maps[currentMapIndex];
        GameSettings.Map = currentMapIndex;

        rightArrowButton.gameObject.SetActive(currentMapIndex < maps.Length - 1);
        leftArrowButton.gameObject.SetActive(currentMapIndex > 0);
    }

    void PreviousMap()
    {
        if (currentMapIndex > 0)
        {
            currentMapIndex--;
            UpdateMapText();
        }
    }

    void NextMap()
    {
        if (currentMapIndex < maps.Length - 1)
        {
            currentMapIndex++;
            UpdateMapText();
        }
    }
}
