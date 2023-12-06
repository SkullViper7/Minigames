using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeJumpManager : MonoBehaviour
{
    private static SlimeJumpManager _instance = null;
    public static SlimeJumpManager Instance => _instance;

    public List<PlayerMovement> _players = new List<PlayerMovement>();

    public UIPage UI;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        UI = gameObject.AddComponent<UIPage>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerDie(PlayerMovement theDeadPlayer)
    {
        theDeadPlayer._score += TimeManager.Instance.totalScore;
        Debug.Log(theDeadPlayer._score);
        if(_players.Count != 1)
        {
            UI.ChangeNamePlayerDeadUI(theDeadPlayer.gameObject);
            _players.Remove(theDeadPlayer);
        }
        else
        {
            UI.ShowNameWinnerUI(theDeadPlayer.gameObject);
        }
    }

    public void StartTheGame()
    {
        TimeManager.Instance.GameStart();
        SpawnManager.Instance.InvokeTheSpawn("SpawnAnObject", SpawnManager.Instance.maxSpawnTiming);
        SpawnManager.Instance.InvokeTheSpawn("SpawnCoins", SpawnManager.Instance.maxCoinSpawnTiming);
        foreach (var player in _players) 
        {
            player.GameStart();
        }
    }
}
