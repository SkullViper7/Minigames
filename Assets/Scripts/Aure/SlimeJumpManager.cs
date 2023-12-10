using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeJumpManager : MonoBehaviour
{
    private static SlimeJumpManager _instance = null;
    public static SlimeJumpManager Instance => _instance;

    public List<PlayerMovement> _players = new List<PlayerMovement>();
    public List<PlayerMovement> _playersDead = new List<PlayerMovement>();

    public UIPage UI;

    public bool _isEndGame;
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
        _playersDead.Add(theDeadPlayer);
        if (_players.Count != 1)
        {
            UI.ChangeNamePlayerDeadUI(theDeadPlayer.gameObject);
            _players.Remove(theDeadPlayer);
        }
        else
        {
            UI.ShowNameWinnerUI(theDeadPlayer.gameObject);
            _playersDead.Sort(Compare);
            UI.ShowPodium();
            _isEndGame = true;
            foreach (GameObject _obj in FindObjectsOfType(typeof(GameObject)))
            {
                if(_obj.tag == "Coin" || _obj.tag == "Projectile" || (_obj.tag == "Wall" && _obj.GetComponent<SpawnObjects>() != null))
                {
                    _obj.SetActive(false);
                }
                
            }
        }
    }
    public int Compare(PlayerMovement x, PlayerMovement y)
    {
        return y._score.CompareTo(x._score);
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
}
