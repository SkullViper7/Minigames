using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        player2Score.text = scoreManager.player2Score.ToString();
        player3Score.text = scoreManager.player3Score.ToString();
        player4Score.text = scoreManager.player4Score.ToString();
    }
}
