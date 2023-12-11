using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class RocketRideManager : MonoBehaviour
{
    //Singleton
    private static RocketRideManager _instance = null;
    private RocketRideManager() { }
    public static RocketRideManager Instance => _instance;
    //

    public GameObject[] rockets;
    public List<GameObject> rocketsWhichHaveFinished = new();
    public List<GameObject> rocketsWhichHaveNotFinished = new();

    public bool gameIsOver;

    public GameObject mainMusic;

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

        //Create an object to play main music if there is no one in the scene
        if (!GameObject.FindGameObjectWithTag("RocketRideMainMusic"))
        {
            GameObject newMainLeaderboardManager = Instantiate(mainMusic, Vector3.zero, Quaternion.Euler(0, 0, 0));
            newMainLeaderboardManager.name = "MainMusic";
            DontDestroyOnLoad(newMainLeaderboardManager);
        }

        #if !UNITY_EDITOR
        GarbageCollector.GCMode = GarbageCollector.Mode.Disabled;
        #endif
        System.GC.Collect();
    }

    private void Start()
    {
        gameIsOver = true;

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