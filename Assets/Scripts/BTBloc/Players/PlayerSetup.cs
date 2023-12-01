using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetup : MonoBehaviour
{
    // Utilisation du tuto : https://www.youtube.com/watch?v=HsxQ1P9Tlc0

    public Renderer m_renderer;
    public Camera m_mainCamera;

    public GameObject[] m_cameras;
    private Vector3 m_startPosition;
    private bool m_hasStartPositionBeenApplied;

    private const int DEFAULT_CULLING_MASK = 1 << 0 | 1 << 2 | 1 << 4 | 1 << 5;

    public void SetMaterial(Material playerMaterial)
    {
        m_renderer.material = playerMaterial;
    }

    public void SetCameraLayer(string s)
    {
        var layerInt = LayerMask.NameToLayer(s);
        foreach (var cameraObject in m_cameras)
        {
            cameraObject.layer = layerInt;
        }
    }

    public void SetCameraCulling(string s)
    {
        var layerInt = LayerMask.NameToLayer(s);
        var culling = 1 << layerInt | DEFAULT_CULLING_MASK;

        m_mainCamera.cullingMask = culling;
    }

    public void SetPlayerStartPosition(Transform startPosition)
    {
        m_startPosition = startPosition.position;
    }

    private void LateUpdate()
    {
        if (m_hasStartPositionBeenApplied == false)
        {
            m_hasStartPositionBeenApplied = true;
            transform.parent.position = m_startPosition;
        }
    }
}
