using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChooseNumberOfPlayerWithGamepad : MonoBehaviour
{
    public GameObject choiceWindow;
    public GameObject lobbyWindow;

    public void Click(int _numberOfPlayer)
    {
        //Set the max number of player and show the lobby screen
        GameManager.Instance.maxPlayerCount = _numberOfPlayer;
        lobbyWindow.SetActive(true);
        choiceWindow.SetActive(false);
    }
}
