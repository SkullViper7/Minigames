using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Camera playerCam1;
    public Camera playerCam2;
    public Camera playerCam3;
    public Camera playerCam4;

    // Resize Camera for x player to have split screens
    void Start()
    {
        if (GameManager.Instance.maxPlayerCount == 2)
        {
            playerCam1.rect = new Rect(0f, 0f, 1 / 2f, 1f);
            playerCam2.rect = new Rect(1 / 2f, 0f, 1 / 2f, 1f);
        }
        else if (GameManager.Instance.maxPlayerCount == 3)
        {
            playerCam1.rect = new Rect(0f, 0f, 1 / 3f, 1f);
            playerCam2.rect = new Rect(1 / 3f, 0f, 1 / 3f, 1f);
            playerCam3.rect = new Rect(2 / 3f, 0f, 1 / 3f, 1f);
        }
        else if (GameManager.Instance.maxPlayerCount == 4)
        {
            playerCam1.rect = new Rect(0f, 0f, 1 / 4f, 1f);
            playerCam2.rect = new Rect(1 / 4f, 0f, 1 / 4f, 1f);
            playerCam3.rect = new Rect(2 / 4f, 0f, 1 / 4f, 1f);
            playerCam4.rect = new Rect(3 / 4f, 0f, 1 / 4f, 1f);
        }
    }


}
