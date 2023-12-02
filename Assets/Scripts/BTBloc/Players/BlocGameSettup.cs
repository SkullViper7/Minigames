using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlocGameSettup : MonoBehaviour
{
    // Utilisation du tuto : https://www.youtube.com/watch?v=HsxQ1P9Tlc0

    public Transform[] m_startPosition;
    public Material[] m_playerMaterial;
    public string[] m_playerCameraLayer;
    private int m_playerIndex;

    public void HandleNewPlayerConnection(PlayerInput _player)
    {
        print("HandleNewPlayerConnection with device " + _player.devices);
        var playerSetup = _player.GetComponent<PlayerSetup>();

        playerSetup.SetMaterial(m_playerMaterial[m_playerIndex]);
        playerSetup.SetCameraLayer(m_playerCameraLayer[m_playerIndex]);
        playerSetup.SetCameraCulling(m_playerCameraLayer[m_playerIndex]);
        playerSetup.SetPlayerStartPosition(m_startPosition[m_playerIndex]);

        m_playerIndex++;
    }
}