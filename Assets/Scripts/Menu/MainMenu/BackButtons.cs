using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButtons : MonoBehaviour
{
    public void BackButton(string _previousSceneName)
    {
        SceneManager.LoadScene(_previousSceneName);
    }
}
