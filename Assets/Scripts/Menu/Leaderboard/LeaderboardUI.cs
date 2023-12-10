using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Linq;

public class LeaderboardUI : MonoBehaviour
{
    [Header("Dumb Quiz")]
    [SerializeField]
    private List<TextMeshProUGUI> quizNames = new();
    [SerializeField]
    private List<TextMeshProUGUI> quizScores = new();
    private Dictionary<string, int> quizLeaderboard = new Dictionary<string, int> { { "Player1", 0 }, { "Player2", 0 }, { "Player3", 0 }, { "Player4", 0 } };

    [Header("Slime Jump")]
    [SerializeField]
    private List<TextMeshProUGUI> slimeNames = new();
    [SerializeField]
    private List<TextMeshProUGUI> slimScores = new();
    [SerializeField]
    private TextMeshProUGUI slimeBestScore;
    private Dictionary<string, int> slimeLeaderboard = new Dictionary<string, int> { { "Player1", 0 }, { "Player2", 0 }, { "Player3", 0 }, { "Player4", 0 } };

    [Header("Rocket Ride")]
    [SerializeField]
    private List<TextMeshProUGUI> rocketNames = new();
    [SerializeField]
    private List<TextMeshProUGUI> rocketScores = new();
    [SerializeField]
    private TextMeshProUGUI rocketBestChrono;
    private Dictionary<string, int> rocketLeaderboard = new Dictionary<string, int> { { "Player1", 0 }, { "Player2", 0 }, { "Player3", 0 }, { "Player4", 0 } };

    [Header("BTBloc")]
    [SerializeField]
    private List<TextMeshProUGUI> btNames = new();
    [SerializeField]
    private List<TextMeshProUGUI> btScores = new();
    [SerializeField]
    private TextMeshProUGUI btHighestSpeed;
    private Dictionary<string, int> btLeaderboard = new Dictionary<string, int> { { "Player1", 0 }, { "Player2", 0 }, { "Player3", 0 }, { "Player4", 0 } };

    private void Start()
    {
        DisplayLeaderboard();
    }

    private void DisplayLeaderboard()
    {
        GetAllData();
        SortAllLeaderboards();

        //Display all values at screen

        //Dumb Quiz
        for (int i = 0; i < quizLeaderboard.Count; i++)
        {
            var kvp = quizLeaderboard.ElementAt(i);
            quizNames[i].text = kvp.Key;
            quizScores[i].text = kvp.Value.ToString();
        }

        //Slime Jump
        for (int i = 0; i < slimeLeaderboard.Count; i++)
        {
            var kvp = slimeLeaderboard.ElementAt(i);
            slimeNames[i].text = kvp.Key;
            slimScores[i].text = kvp.Value.ToString();
        }
        slimeBestScore.text = PlayerPrefs.GetInt("SlimeJumpBestScore").ToString();

        //Rocket Ride
        for (int i = 0; i < rocketLeaderboard.Count; i++)
        {
            var kvp = rocketLeaderboard.ElementAt(i);
            rocketNames[i].text = kvp.Key;
            rocketScores[i].text = kvp.Value.ToString();
        }
        rocketBestChrono.text = ConvertChronoToString(PlayerPrefs.GetInt("RocketRideBestTimeMinutes")) + " : " +
                                ConvertChronoToString(PlayerPrefs.GetInt("RocketRideBestTimeSeconds")) + " : " +
                                ConvertChronoToString(PlayerPrefs.GetInt("RocketRideBestTimeCentiseconds"));

        //BTBloc
        for (int i = 0; i < btLeaderboard.Count; i++)
        {
            var kvp = btLeaderboard.ElementAt(i);
            btNames[i].text = kvp.Key;
            btScores[i].text = kvp.Value.ToString();
        }
        btHighestSpeed.text = PlayerPrefs.GetFloat("BTBlocFastest").ToString() + " blocs/sec";
    }

    private void GetAllData()
    {
        //Get all scores in player prefs

        //Dumb Quiz
        quizLeaderboard["Player1"] = PlayerPrefs.GetInt("QuizPlayer1");
        quizLeaderboard["Player2"] = PlayerPrefs.GetInt("QuizPlayer2");
        quizLeaderboard["Player3"] = PlayerPrefs.GetInt("QuizPlayer3");
        quizLeaderboard["Player4"] = PlayerPrefs.GetInt("QuizPlayer4");

        //Slime Jump
        slimeLeaderboard["Player1"] = PlayerPrefs.GetInt("SlimeJumpPlayer1");
        slimeLeaderboard["Player2"] = PlayerPrefs.GetInt("SlimeJumpPlayer2");
        slimeLeaderboard["Player3"] = PlayerPrefs.GetInt("SlimeJumpPlayer3");
        slimeLeaderboard["Player4"] = PlayerPrefs.GetInt("SlimeJumpPlayer4");

        //Rocket Ride
        rocketLeaderboard["Player1"] = PlayerPrefs.GetInt("RocketRidePlayer1");
        rocketLeaderboard["Player2"] = PlayerPrefs.GetInt("RocketRidePlayer2");
        rocketLeaderboard["Player3"] = PlayerPrefs.GetInt("RocketRidePlayer3");
        rocketLeaderboard["Player4"] = PlayerPrefs.GetInt("RocketRidePlayer4");

        //BTBloc
        btLeaderboard["Player1"] = PlayerPrefs.GetInt("BTBlocPlayer1");
        btLeaderboard["Player2"] = PlayerPrefs.GetInt("BTBlocPlayer2");
        btLeaderboard["Player3"] = PlayerPrefs.GetInt("BTBlocPlayer3");
        btLeaderboard["Player4"] = PlayerPrefs.GetInt("BTBlocPlayer4");
    }

    private void SortAllLeaderboards()
    {
        //Sort all dictionnaries by descending order
        quizLeaderboard = quizLeaderboard.OrderByDescending(_player => _player.Value).ToDictionary(_player => _player.Key, _player => _player.Value);
        slimeLeaderboard = slimeLeaderboard.OrderByDescending(_player => _player.Value).ToDictionary(_player => _player.Key, _player => _player.Value);
        rocketLeaderboard = rocketLeaderboard.OrderByDescending(_player => _player.Value).ToDictionary(_player => _player.Key, _player => _player.Value);
        btLeaderboard = btLeaderboard.OrderByDescending(_player => _player.Value).ToDictionary(_player => _player.Key, _player => _player.Value);
    }

    public void ResetLeaderboard(string _game)
    {
        //Reset values of a leaderboard
        switch (_game)
        {
            case "Quiz":
                PlayerPrefs.SetInt("QuizPlayer1", 0);
                PlayerPrefs.SetInt("QuizPlayer2", 0);
                PlayerPrefs.SetInt("QuizPlayer3", 0);
                PlayerPrefs.SetInt("QuizPlayer4", 0);
                break;
            case "SlimeJump":
                PlayerPrefs.SetInt("SlimeJumpPlayer1", 0);
                PlayerPrefs.SetInt("SlimeJumpPlayer2", 0);
                PlayerPrefs.SetInt("SlimeJumpPlayer3", 0);
                PlayerPrefs.SetInt("SlimeJumpPlayer4", 0);
                break;
            case "RocketRide":
                PlayerPrefs.SetInt("RocketRidePlayer1", 0);
                PlayerPrefs.SetInt("RocketRidePlayer2", 0);
                PlayerPrefs.SetInt("RocketRidePlayer3", 0);
                PlayerPrefs.SetInt("RocketRidePlayer4", 0);
                break;
            case "BTBloc":
                PlayerPrefs.SetInt("BTBlocPlayer1", 0);
                PlayerPrefs.SetInt("BTBlocPlayer2", 0);
                PlayerPrefs.SetInt("BTBlocPlayer3", 0);
                PlayerPrefs.SetInt("BTBlocPlayer4", 0);
                break;
        }
        DisplayLeaderboard();
    }

    private string ConvertChronoToString(int _time)
    {
        //Add a 0 before a value if it's less than 10
        if (_time >= 10)
        {
            return _time.ToString();
        }
        else
        {
            return $"{0}{_time}";
        }
    }
}
