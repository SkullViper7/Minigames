using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLeaderboardManager : MonoBehaviour
{
    // Singleton
    private static MainLeaderboardManager _instance = null;
    private MainLeaderboardManager() { }
    public static MainLeaderboardManager Instance => _instance;
    //

    private void Awake()
    {
        // Singleton
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

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        //Values by default

        ////Rocket Ride
        //PlayerPrefs.SetInt("RocketRidePlayer1", 0);
        //PlayerPrefs.SetInt("RocketRidePlayer2", 0);
        //PlayerPrefs.SetInt("RocketRidePlayer3", 0);
        //PlayerPrefs.SetInt("RocketRidePlayer4", 0);
        if (PlayerPrefs.GetInt("RocketRideBestTimeMinutes") == 0 && 
            PlayerPrefs.GetInt("RocketRideBestTimeSeconds") == 0 && 
            PlayerPrefs.GetInt("RocketRideBestTimeCentiseconds") == 0)
            {
                PlayerPrefs.SetInt("RocketRideBestTimeMinutes", 10);
                PlayerPrefs.SetInt("RocketRideBestTimeSeconds", 60);
                PlayerPrefs.SetInt("RocketRideBestTimeCentiseconds", 100);
            }

        ////Quiz
        //PlayerPrefs.SetInt("QuizPlayer1", 0);
        //PlayerPrefs.SetInt("QuizPlayer2", 0);
        //PlayerPrefs.SetInt("QuizPlayer3", 0);
        //PlayerPrefs.SetInt("QuizPlayer4", 0);

        ////Slime Jump
        //PlayerPrefs.SetInt("SlimeJumpPlayer1", 0);
        //PlayerPrefs.SetInt("SlimeJumpPlayer2", 0);
        //PlayerPrefs.SetInt("SlimeJumpPlayer3", 0);
        //PlayerPrefs.SetInt("SlimeJumpPlayer4", 0);
        //PlayerPrefs.SetInt("SlimeJumpBestScore", 0);


        ////BTBloc
        //PlayerPrefs.SetInt("BTBlocPlayer1", 0);
        //PlayerPrefs.SetInt("BTBlocPlayer2", 0);
        //PlayerPrefs.SetInt("BTBlocPlayer3", 0);
        //PlayerPrefs.SetInt("BTBlocPlayer4", 0);
        //PlayerPrefs.SetFloat("BTBlocFastest", 0f);
    }

    public void UpdateScore(string _player, int _score)
    {
        //Update the score of the player given
        PlayerPrefs.SetInt(_player, PlayerPrefs.GetInt(_player) + _score);
    }

    public bool IsTheBestTimeEver(List<int> _chrono)
    {
        //Check if the time given time is lower than the best time ever
        if (_chrono[0] <= PlayerPrefs.GetInt("RocketRideBestTimeMinutes"))
        {
            if (_chrono[1] <= PlayerPrefs.GetInt("RocketRideBestTimeSeconds"))
            {
                if (_chrono[2] < PlayerPrefs.GetInt("RocketRideBestTimeCentiseconds"))
                {
                    PlayerPrefs.SetInt("RocketRideBestTimeMinutes", _chrono[0]);
                    PlayerPrefs.SetInt("RocketRideBestTimeSeconds", _chrono[1]);
                    PlayerPrefs.SetInt("RocketRideBestTimeCentiseconds", _chrono[2]);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public bool IsTheFastestEver(float _speed)
    {
        //Check if the speed given is better than the fastest
        if (_speed > PlayerPrefs.GetFloat("BTBlocFastest"))
        {
            PlayerPrefs.SetFloat("BTBlocFastest", _speed);
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsTheBestScore(int _score)
    {
        //Check if the score giver is better than the best
        if (_score > PlayerPrefs.GetInt("SlimeJumpBestScore"))
        {
            PlayerPrefs.SetInt("SlimeJumpBestScore", _score);
            return true;
        }
        else
        {
            return false;
        }
    }
}