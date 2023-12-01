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
    public UnityEngine.InputSystem.PlayerInputManager inputManager;
    public Transform player1Holder;
    public Transform player2Holder;
    public Transform player3Holder;
    public Transform player4Holder;

    [Space]
    public GameObject player1Logo;
    public GameObject player2Logo;
    public GameObject player3Logo;
    public GameObject player4Logo;

    GameObject player;

    public int numberOfPlayers;

    public void RegisterPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<PlayerInput>().user.id == 1)
        {
            player.name = player1SO.name;
            player.tag = "Player1";
            player1Logo.SetActive(true);
            player.GetComponent<Image>().sprite = null;
            player.GetComponent<PlayerController>().enabled = false;
        }

        if (player.GetComponent<PlayerInput>().user.id == 2)
        {
            player.name = player2SO.name;
            player.tag = "Player2";
            player2Logo.SetActive(true);
            player.GetComponent<Image>().sprite = null;
            player.GetComponent<PlayerController>().enabled = false;
        }

        if (player.GetComponent<PlayerInput>().user.id == 3)
        {
            player.name = player3SO.name;
            player.tag = "Player3";
            player3Logo.SetActive(true);
            player.GetComponent<Image>().sprite = null;
            player.GetComponent<PlayerController>().enabled = false;
        }

        if (player.GetComponent<PlayerInput>().user.id == 4)
        {
            player.name = player4SO.name;
            player.tag = "Player4";
            player4Logo.SetActive(true);
            player.GetComponent<Image>().sprite = null;
            player.GetComponent<PlayerController>().enabled = false;
        }

        numberOfPlayers++;
    }
}