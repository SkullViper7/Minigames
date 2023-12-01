using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    float timeMultiplicator;
    float timingToSpeedUp;

    private void Start()
    {
        timeMultiplicator = 0.9f;
        timingToSpeedUp = 3;
        SpeedUp();
    }
    void Update()
    {
        
        

    }

    private void SpeedUp()
    {
        timeMultiplicator += 0.1f;
        timingToSpeedUp = 3 * timeMultiplicator;
        Time.timeScale = timeMultiplicator;
        Invoke("SpeedUp", timingToSpeedUp);
    }
}
