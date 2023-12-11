using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawned : SpawnObjects
{
    public List<float> positionRandomToSpawnOnX = new List<float>();
    
    //va faire spawn un projectile dans une position random au dessus des joueurs
    public void RandomSpawn()
    {
        transform.position = new Vector2(positionRandomToSpawnOnX[Random.Range(0, positionRandomToSpawnOnX.Count)], transform.position.y);
    }
}
