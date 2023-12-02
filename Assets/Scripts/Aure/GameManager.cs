using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;

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
        if(_players.Count != 1)
        {
            UI.ChangeNamePlayerDeadUI(theDeadPlayer.gameObject);
            _players.Remove(theDeadPlayer);
        }
        else
        {

        }
    }

    public void StartTheGame()
    {
        TimeManager.Instance.GameStart();
        SpawnManager.Instance.InvokeTheSpawn();
        foreach (var player in _players) 
        {
            player.GameStart();
        }
    }
}
