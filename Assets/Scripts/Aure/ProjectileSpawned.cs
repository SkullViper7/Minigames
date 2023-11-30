using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawned : SpawnObjects
{
    public List<float> positionRandomToSpawnOnX = new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        RandomSpawn();
    }

    public void RandomSpawn()
    {
        transform.position = new Vector2(positionRandomToSpawnOnX[Random.Range(0, positionRandomToSpawnOnX.Count)], transform.position.y);
    }
}
