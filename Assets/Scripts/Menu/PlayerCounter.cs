using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCounter : MonoBehaviour
{
    public PlayerManager manager;

    public void Update()
    {
        if (manager.numberOfPlayers == 2)
        {
            StartCoroutine(PlayGame());
        }
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("QuizGame");
    }
}