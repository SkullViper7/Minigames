using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChoiceBackButton : MonoBehaviour
{
    [SerializeField]
    private GameObject playerChoiceWindow;
    [SerializeField]
    private GameObject lobbyWindow;
    [SerializeField]
    private PlayerCounter playerCounter;
    [SerializeField]
    private PlayerInputManager playerInputManager;

    public void BackToChoice()
    {
        GameManager.Instance.ClearPlayerInputControls();
        playerChoiceWindow.SetActive(true);

        playerInputManager.DisableJoining();

        //Desactive player holders
        foreach (GameObject playerHolder in playerCounter.playerHolders)
        {
            playerHolder.SetActive(false);
        }

        lobbyWindow.SetActive(false);
    }
}
