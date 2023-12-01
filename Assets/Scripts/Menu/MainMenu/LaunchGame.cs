using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGame : MonoBehaviour
{
    public enum Game { Quiz, RocketRide, SlimeJump, BTBloc };
    public Game game;

    public void GoToPlayerChoice()
    {
        GameManager.Instance.game = game.ToString();
        SceneManager.LoadScene("PlayerChoiceWithGamepad");
    }
}
