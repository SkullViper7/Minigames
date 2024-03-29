using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine.SceneManagement;

public class BlocUI_Manager : MonoBehaviour
{
    public TMP_Text _uiTimer;
    AudioSource audioData;

    //Singleton
    private static BlocUI_Manager _instance = null;
    private BlocUI_Manager() { }
    public static BlocUI_Manager Instance => _instance;
    //

    public TMPro.TMP_Text[] rankUI;
    public TMPro.TMP_Text[] playerNumberUI;
    public TMPro.TMP_Text[] scoresUI;

    public GameObject leaderBoard;
    public GameObject newScore;

    public Color green;
    public Color red;
    public Color blue;
    public Color yellow;

    public bool isCountDown = true;

    public Dictionary<string, int> scoresPlayers = new Dictionary<string, int>();

    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        //
        audioData = GetComponent<AudioSource>();
    }

    private string PlayerName(string _player)
    {
        //Return the name associated to the player given
        switch (_player)
        {
            case "Bloc_Player_1":
                return "Player1";
            case "Bloc_Player_2":
                return "Player2";
            case "Bloc_Player_3":
                return "Player3";
            case "Bloc_Player_4":
                return "Player4";
            default: return "-";
        }
    }

    private Color PlayerColor(string _player)
    {
        //Return the color associated to the player given
        switch (_player)
        {
            case "Bloc_Player_1":
                return green;
            case "Bloc_Player_2":
                return red;
            case "Bloc_Player_3":
                return blue;
            case "Bloc_Player_4":
                return yellow;
            default: return Color.white;
        }
    }

    //Display the Time on UI 
    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _uiTimer.text = string.Format("{00}", seconds);
    }

    //Display the Score on UI 
    public void DisplayScores()
    {
        scoresPlayers = scoresPlayers.OrderByDescending(_player => _player.Value).ToDictionary(_player => _player.Key, _player => _player.Value);

        for (int i = 0; i < scoresPlayers.Count; i++)
        {
            rankUI[i].text = (i + 1).ToString();
            var kvp = scoresPlayers.ElementAt(i);
            if (i == 0)
            {
                if (MainLeaderboardManager.Instance.IsTheFastestEver(kvp.Value / 10f))
                {
                    newScore.SetActive(true);
                }
            }
            playerNumberUI[i].text = PlayerName(kvp.Key);
            playerNumberUI[i].color = PlayerColor(kvp.Key);
            scoresUI[i].text = kvp.Value.ToString();
            AddScoreInMainLeaderboard(kvp.Key, kvp.Value);
        }
    }

    public void RestartGame()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void MainMenu()
    {
        GameManager.Instance.ResetManager();
        SceneManager.LoadScene("MainMenu");
    }

    public void CountDownFinished()
    {
        isCountDown = false;
    }
    public void CountDownSound()
    {
        audioData.Play();
    }

    private void AddScoreInMainLeaderboard(string _player, int _score)
    {
        //Add score in the main leaderboard for the player given and his position
        switch (_player)
        {
            case "Bloc_Player_1":
                MainLeaderboardManager.Instance.UpdateScore("BTBlocPlayer1", _score);
                break;
            case "Bloc_Player_2":
                MainLeaderboardManager.Instance.UpdateScore("BTBlocPlayer2", _score);
                break;
            case "Bloc_Player_3":
                MainLeaderboardManager.Instance.UpdateScore("BTBlocPlayer3", _score);
                break;
            case "Bloc_Player_4":
                MainLeaderboardManager.Instance.UpdateScore("BTBlocPlayer4", _score);
                break;
        }
    }
}
