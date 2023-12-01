using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start()
    {
        //Check which minigame is choosen and determine the player to activate
        switch (GameManager.Instance.game)
        {
            case "Quiz":
                break;
            case "RocketRide":
                ActivePlayer("Rocket");
                break;
            case "SlimeJump":
                break;
            case "BTBloc":
                break;

        }
    }

    private void ActivePlayer(string _name)
    {
        //Active the good child depending of the mini game
        GameObject player = transform.Find(_name).gameObject;

        if (player != null)
        {
            player.SetActive(true);
        }
    }
}
