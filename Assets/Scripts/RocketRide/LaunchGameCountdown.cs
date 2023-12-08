using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchGameCountdown : MonoBehaviour
{
    private GameObject countdownWindow;
    [SerializeField]
    private GameObject gameWindow;

    private void Start()
    {
        countdownWindow = this.gameObject;
    }

    public void EndOfTheCountdown()
    {
        RocketRideManager.Instance.gameIsOver = false;
        gameWindow.SetActive(true);
        RocketRideChronoManager.Instance.StartChrono();
        countdownWindow.SetActive(false);
    }
}
