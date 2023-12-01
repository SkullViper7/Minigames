using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerCounter : MonoBehaviour
{
    private PlayerInputManager playerInputManager;

    private void Start()
    {
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    public void OnPlayerConneted()
    {
        //Add a player in the count if a player joines and disable joining if the maximum of player is reached
        if (GameManager.Instance.playerCount + 1 >= GameManager.Instance.maxPlayerCount)
        {
            playerInputManager.DisableJoining();
            GameManager.Instance.playerCount++;
        }
        else
        {
            GameManager.Instance.playerCount++;
        }
    }

    public void OnPlayerDisconnected()
    {
        //Remove a player in the count if a player quites
        GameManager.Instance.playerCount--;
    }
}