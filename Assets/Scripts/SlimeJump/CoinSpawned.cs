using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawned : SpawnObjects
{
    public float _MinXToSpawn;
    public float _MaxXToSpawn;

    //crée une pièce à une position random au dessus des joueurs
    public void RandomSpawn()
    {
        transform.position = new Vector2(Random.Range(_MinXToSpawn, _MaxXToSpawn), transform.position.y);
    }
}
