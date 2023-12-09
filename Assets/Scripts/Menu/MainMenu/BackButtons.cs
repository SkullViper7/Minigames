using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtons : MonoBehaviour
{
    public void BackButton(string _previousSceneName)
    {
        if (_previousSceneName == "MainMenu")
        {
            GameManager.Instance.ClearMainLeaderboardManager();
        }
        SceneManager.LoadScene(_previousSceneName);
    }
}
