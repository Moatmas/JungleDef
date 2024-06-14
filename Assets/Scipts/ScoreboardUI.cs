using UnityEngine;
using TMPro;  
using PlayFab.ClientModels;

public class ScoreboardUI : MonoBehaviour
{
    public TextMeshProUGUI leaderboardText;

    public void UpdateLeaderboard(GetLeaderboardResult result)
    {
        leaderboardText.text = "";
        foreach (var item in result.Leaderboard)
        {
            leaderboardText.text += $"{item.Position + 1}. {item.DisplayName}: {item.StatValue}\n";
        }
    }
}
