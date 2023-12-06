using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(GameManager.Instance.game);
    }

    public void Menu()
    {
        GameManager.Instance.ResetManager();
        SceneManager.LoadScene("MainMenu");
    }
}
