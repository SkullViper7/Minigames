using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGameWithGamepad : MonoBehaviour
{
    public void LaunchGame()
    {
        //Launch the game when everyone is connected
        if (GameManager.Instance.playerCount == GameManager.Instance.maxPlayerCount)
        {
            SceneManager.LoadScene(GameManager.Instance.game);
        }
    }
}
