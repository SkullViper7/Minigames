using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;

public class EndGameButton : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene(GameManager.Instance.game);
        System.GC.Collect();
    }

    public void Menu()
    {
        GameManager.Instance.ResetManager();
        Destroy(GameObject.FindGameObjectWithTag("RocketRideMainMusic"));
        System.GC.Collect();
        #if !UNITY_EDITOR
        GarbageCollector.GCMode = GarbageCollector.Mode.Enabled;
        #endif
        SceneManager.LoadScene("MainMenu");
    }
}
