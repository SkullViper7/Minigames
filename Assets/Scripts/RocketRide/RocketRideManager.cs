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

    public GameObject[] rockets;
    public List<GameObject> rocketsWhichHaveFinished = new();
    public List<GameObject> rocketsWhichHaveNotFinished = new();

    public bool gameIsOver;

    private void Start()
    {
        gameIsOver = false;

        //Get all rockets
        rockets = GameObject.FindGameObjectsWithTag("Rocket");
    }

    public void GetRocketsWhichHaveNotFinished()
    {
        //Get rockets which have not finished the race
        for (int i = 0; i < rockets.Length; i++)
        {
            if (!rocketsWhichHaveFinished.Contains(rockets[i]))
            {
                rocketsWhichHaveNotFinished.Add(rockets[i]);
            }
        }
    }
}
