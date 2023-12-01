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
        DontDestroyOnLoad(gameObject);
        gameObject.name = "PlayerInputControl" + GameManager.Instance.playerCount.ToString();
        playerInput = GetComponent<PlayerInput>();
        playerInput.SwitchCurrentActionMap(GameManager.Instance.game);
    }
}
