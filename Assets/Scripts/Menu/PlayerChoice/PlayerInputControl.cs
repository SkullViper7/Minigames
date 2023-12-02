using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputControl : MonoBehaviour

{
    private PlayerInput playerInput;

    private void Awake()
    {
        //Set the player Input Control prefab in don't destroy on load with a unique name and the good action map
        DontDestroyOnLoad(gameObject);
        gameObject.name = "PlayerInputControl" + GameManager.Instance.playerCount.ToString();
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap(GameManager.Instance.game);
    }
}
