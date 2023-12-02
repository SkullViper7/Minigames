using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseNumberOfPlayerWithKeyboard : MonoBehaviour
{
    public GameObject playerInputControl;

    public void Click(int _numberOfPlayer)
    {
        //Create the Player Input Control for keyboard
        GameObject newPlayerInputControl = Instantiate(playerInputControl, Vector3.zero, Quaternion.Euler(0, 0, 0));

        //Set the max number of player and show the lobby screen
        GameManager.Instance.maxPlayerCount = _numberOfPlayer;

        //Launch the game
        SceneManager.LoadScene(GameManager.Instance.game);
    }
}
