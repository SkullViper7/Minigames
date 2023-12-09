using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class LeaderboardManager : MonoBehaviour
{
    public TMP_Text player1Score;
    public TMP_Text player2Score;
    public TMP_Text player3Score;
    public TMP_Text player4Score;

    [Space]
    public ScoreManager scoreManager;

    public void ShowScore()
    {
        player1Score.text = scoreManager.player1Score.ToString();
        MainLeaderboardManager.Instance.UpdateScore("QuizPlayer1", scoreManager.player1Score);
        player2Score.text = scoreManager.player2Score.ToString();
        MainLeaderboardManager.Instance.UpdateScore("QuizPlayer2", scoreManager.player2Score);
        player3Score.text = scoreManager.player3Score.ToString();
        MainLeaderboardManager.Instance.UpdateScore("QuizPlayer3", scoreManager.player3Score);
        player4Score.text = scoreManager.player4Score.ToString();
        MainLeaderboardManager.Instance.UpdateScore("QuizPlayer4", scoreManager.player4Score);
    }
}
