using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoiceBackButton : MonoBehaviour
{
    public GameObject playerChoiceWindow;
    public GameObject lobbyWindow;

    public void BackToChoice()
    {
        GameManager.Instance.ClearPlayerInputControls();
        playerChoiceWindow.SetActive(true);
        lobbyWindow.SetActive(false);
    }
}
