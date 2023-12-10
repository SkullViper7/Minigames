using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;
    //

    [HideInInspector]
    public string game = "";

    [HideInInspector]
    public bool isOnKeyboard;

    //[HideInInspector]
    public int maxPlayerCount;
    //[HideInInspector]
    public int playerCount;

    [HideInInspector]
    public List<GameObject> playerInputControls = new();

    [SerializeField]
    private GameObject mainLeaderboardManagerPrefab;
    private GameObject mainLeaderboardManager;

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

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        playerCount = 0;
    }

    public void InitializeMainLeaderboardManager()
    {
        //Create a leaderboard manager when a game is chosen
        GameObject newMainLeaderboardManager = Instantiate(mainLeaderboardManagerPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        newMainLeaderboardManager.name = "MainLeaderboardManager";
        mainLeaderboardManager = newMainLeaderboardManager;
    }

    public void ClearMainLeaderboardManager()
    {
        //Delete main leaderboard manager
        Destroy(mainLeaderboardManager);
        mainLeaderboardManager = null;
    }

    public void ClearPlayerInputControls()
    {
        //Delete all playerInputControls
        foreach (GameObject playerInputControl in playerInputControls)
        {
            Destroy(playerInputControl);
        }
        playerInputControls.Clear();
        playerCount = 0;
    }

    public void ResetManager()
    {
        //Reset all values
        game = "";
        isOnKeyboard = false;
        maxPlayerCount = 0;
        
        ClearPlayerInputControls();
        ClearMainLeaderboardManager();
    }
}
