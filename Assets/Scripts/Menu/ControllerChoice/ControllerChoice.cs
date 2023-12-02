using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControllerChoice : MonoBehaviour
{
    public void OnControllerChoice(bool _isKeyboard)
    {
        GameManager.Instance.isOnKeyboard = _isKeyboard;

        if (_isKeyboard)
        {
            SceneManager.LoadScene(GameManager.Instance.game);
        }
        else
        {
            SceneManager.LoadScene("PlayerChoiceWithGamepad");
        }
    }
}
