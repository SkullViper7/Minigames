using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaunchSceneButton : MonoBehaviour
{
    public void LaunchScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
}
