using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketRideManager : MonoBehaviour
{
    //Singleton
    private static RocketRideManager _instance = null;
    private RocketRideManager() { }
    public static RocketRideManager Instance => _instance;
    //

    private void Awake()
    {
        //Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
        //
    }

    public List<GameObject> rocketsWhichHaveFinished = new();

    public bool gameIsOver;

    private void Start()
    {
        gameIsOver = false;
    }
}
