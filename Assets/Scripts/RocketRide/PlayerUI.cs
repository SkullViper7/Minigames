using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public GameObject camera;
    public GameObject player;

    public float cameraStartPosZ;
    public Vector3 playerUiStartScale;

    private void Start()
    {
        camera = GameObject.FindGameObjectWithTag("RocketRideCamera");

        cameraStartPosZ = camera.transform.position.z;
        playerUiStartScale = transform.localScale;
    }

    private void FixedUpdate()
    {
        transform.eulerAngles = new Vector3(0f, 0f, -player.transform.rotation.z);
        transform.localScale = new Vector3(((playerUiStartScale.x * camera.transform.position.z) / cameraStartPosZ),
                                           ((playerUiStartScale.y * camera.transform.position.z) / cameraStartPosZ),
                                           ((playerUiStartScale.z * camera.transform.position.z) / cameraStartPosZ));
    }
}
