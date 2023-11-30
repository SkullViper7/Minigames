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
    public Transform player1Holder;
    public Transform player2Holder;
    public Transform player3Holder;
    public Transform player4Holder;

    [Header("Logos")]
    public Sprite green;
    public Sprite red;
    public Sprite blue;
    public Sprite yellow;

    GameObject player;


    public void RegisterPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player.GetComponent<PlayerInput>().user.id == 1)
        {
            player.name = player1SO.name;
            player.tag = "Player1";
            player.GetComponent<Image>().sprite = green;
            player.transform.SetParent(player1Holder);
            player.transform.localPosition = Vector3.zero;
        }

        if (player.GetComponent<PlayerInput>().user.id == 2)
        {
            player.name = player2SO.name;
            player.tag = "Player2";
            player.GetComponent<Image>().sprite = red;
            player.transform.SetParent(player2Holder);
            player.transform.localPosition = Vector3.zero;
        }

        if (player.GetComponent<PlayerInput>().user.id == 3)
        {
            player.name = player3SO.name;
            player.tag = "Player3";
            player.GetComponent<Image>().sprite = blue;
            player.transform.SetParent(player3Holder);
            player.transform.localPosition = Vector3.zero;
        }

        if (player.GetComponent<PlayerInput>().user.id == 4)
        {
            player.name = player4SO.name;
            player.tag = "Player4";
            player.GetComponent<Image>().sprite = yellow;
            player.transform.SetParent(player4Holder);
            player.transform.localPosition = Vector3.zero;
        }
    }
}
