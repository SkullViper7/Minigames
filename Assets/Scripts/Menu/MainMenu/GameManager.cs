using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Singleton
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;
    //

    public string game = "";

    public bool isOnKeyboard;

    public int maxPlayerCount;
    public int playerCount;

    public List<GameObject> playerInputControls = new();

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
        playerCount = 0;
        foreach (GameObject playerInputControl in playerInputControls)
        {
            Destroy(playerInputControl);
        }
        playerInputControls.Clear();
    }
}
