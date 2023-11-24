using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    [Header("ScriptableObjects")]
    public Player player1SO;
    public Player player2SO;
    public Player player3SO;
    public Player player4SO;

    [Space]
    public PlayerInputManager inputManager;
    public GameObject canvas;

    [Header("Logos")]
    public Sprite green;
    public Sprite red;
    public Sprite blue;
    public Sprite yellow;

    [Space]
    GameObject player1;
    GameObject player2;
    GameObject player3;
    GameObject player4;

    int spawnedPlayers = 0;

    public void RegisterPlayer()
    {
        if (spawnedPlayers == 0)
        {
            inputManager.playerPrefab.name = player1SO.name;
            inputManager.playerPrefab.tag = "Player1";
            inputManager.playerPrefab.GetComponent<Image>().sprite = green;
            player1 = GameObject.FindGameObjectWithTag("Player1");
            player1.transform.SetParent(canvas.transform);
            player1.transform.position = Vector3.zero;
        }

        if (spawnedPlayers == 1)
        {
            inputManager.playerPrefab.name = player2SO.name;
            inputManager.playerPrefab.tag = "Player2";
            inputManager.playerPrefab.GetComponent<Image>().sprite = red;
            player2 = GameObject.FindGameObjectWithTag("Player2");
            player2.transform.SetParent(canvas.transform);
            player2.transform.position = Vector3.zero;
        }

        if (spawnedPlayers == 2)
        {
            inputManager.playerPrefab.name = player3SO.name;
            inputManager.playerPrefab.tag = "Player3";
            inputManager.playerPrefab.GetComponent<Image>().sprite = blue;
            player3 = GameObject.FindGameObjectWithTag("Player3");
            player3.transform.SetParent(canvas.transform);
            player3.transform.position = Vector3.zero;
        }

        if (spawnedPlayers == 3)
        {
            inputManager.playerPrefab.name = player4SO.name;
            inputManager.playerPrefab.tag = "Player4";
            inputManager.playerPrefab.GetComponent<Image>().sprite = yellow;
            player4 = GameObject.FindGameObjectWithTag("Player4");
            player4.transform.SetParent(canvas.transform);
            player4.transform.position = Vector3.zero;
        }

        spawnedPlayers++;
    }
}
