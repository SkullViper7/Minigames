using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance = null;
    public static GameManager Instance => _instance;

    List<PlayerMovement> _players = new List<PlayerMovement>();

    UIPage UI;
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
        UI = new UIPage();
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
        
        _players.Remove(theDeadPlayer);
    }
}
