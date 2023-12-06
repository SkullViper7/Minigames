using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchGameWithKeyboard : MonoBehaviour
{
    public void LaunchGame()
    {

        SceneManager.LoadScene(GameManager.Instance.game);

    }
}
