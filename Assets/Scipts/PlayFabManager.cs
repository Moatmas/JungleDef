using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;
using System.Collections.Generic;

public class PlayFabManager : MonoBehaviour
{
    public static PlayFabManager Instance;
    public ScoreboardUI scoreboardUI; // Ajoutez cette ligne pour faire référence à ScoreboardUI

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SendScore(int score)
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "Score",
                    Value = score
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnStatisticsUpdateSuccess, OnStatisticsUpdateFailure);
    }

    private void OnStatisticsUpdateSuccess(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Score successfully sent to PlayFab.");
    }

    private void OnStatisticsUpdateFailure(PlayFabError error)
    {
        Debug.LogError("Error sending score to PlayFab: " + error.GenerateErrorReport());
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "Score",
            StartPosition = 0,
            MaxResultsCount = 10
        };

        PlayFabClientAPI.GetLeaderboard(request, OnGetLeaderboardSuccess, OnGetLeaderboardFailure);
    }

    private void OnGetLeaderboardSuccess(GetLeaderboardResult result)
    {
        Debug.Log("Leaderboard successfully retrieved from PlayFab.");
        foreach (var item in result.Leaderboard)
        {
            Debug.Log(string.Format("Position: {0} PlayFabId: {1} DisplayName: {2} StatValue: {3}",
                item.Position, item.PlayFabId, item.DisplayName, item.StatValue));
        }
        if (scoreboardUI != null)
        {
            scoreboardUI.UpdateLeaderboard(result);
        }
        else
        {
            Debug.LogError("ScoreboardUI reference is not set in PlayFabManager.");
        }
    }

    private void OnGetLeaderboardFailure(PlayFabError error)
    {
        Debug.LogError("Error retrieving leaderboard from PlayFab: " + error.GenerateErrorReport());
    }
}
