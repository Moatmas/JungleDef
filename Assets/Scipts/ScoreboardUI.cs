using UnityEngine;
using TMPro;
using PlayFab.ClientModels;
using System;

public class ScoreboardUI : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowParent;

    public void UpdateLeaderboard(GetLeaderboardResult result)
    {
        // Clear existing rows
        foreach (Transform child in rowParent)
        {
            Destroy(child.gameObject);
        }

        foreach (var item in result.Leaderboard)
        {
            GameObject newGo = Instantiate(rowPrefab, rowParent);
            TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();

            if (texts.Length >= 3)
            {
                texts[0].text = item.Position.ToString();
                texts[1].text = item.DisplayName ?? "Anonymous";
                texts[2].text = item.StatValue.ToString();

                Debug.Log(string.Format("Place: {0} | ID: {1} | Value: {2}", item.Position, item.PlayFabId, item.StatValue));
            }
            else
            {
                Debug.LogError("The rowPrefab does not have enough TextMeshProUGUI components.");
            }
        }
    }
}
