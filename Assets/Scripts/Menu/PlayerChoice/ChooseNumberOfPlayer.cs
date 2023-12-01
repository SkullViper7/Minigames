using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChooseNumberOfPlayer : MonoBehaviour
{
    public GameObject choiceWindow;
    public GameObject lobbyWindow;

    public void Click(int _numberOfPlayer)
    {
        GameManager.Instance.maxPlayerCount = _numberOfPlayer;
        lobbyWindow.SetActive(true);
        choiceWindow.SetActive(false);
    }
}
