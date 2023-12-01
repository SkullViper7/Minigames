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

    public GameObject playerPrefab;

    private void Start()
    {
        //Check how many players it has to spawn
        switch (GameManager.Instance.maxPlayerCount)
        {
            case 2:
                SpawnPlayers(2);
                break;
            case 3:
                SpawnPlayers(3);
                break;
            case 4:
                SpawnPlayers(4);
                break;
        }
    }

    private void SpawnPlayers(int _number)
    {
        //Spawn the number of players given and rename it with a number
        int index = 1;

        for(int i = 0; i < _number; i++)
        {
            GameObject newPlayer = Instantiate(playerPrefab, transform.position, Quaternion.Euler(0, 0, 0));
            newPlayer.name = "Player" + index.ToString();
            index++;
        }
    }
}
