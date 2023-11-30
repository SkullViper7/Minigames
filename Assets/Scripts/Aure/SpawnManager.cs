using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance = null;
    public static SpawnManager Instance => _instance;

    public GameObject wall;
    public GameObject projectile;
    public List<GameObject> spawnObject = new List<GameObject>();

    public float maxSpawnTiming;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            _instance = this;
        }
    }
    private void Start()
    {
        maxSpawnTiming = 5;
        foreach (GameObject _obj in FindObjectsOfType(typeof(GameObject)))
        {
            if (_obj.name == "Wall")
            {
                wall = _obj;
                _obj.SetActive(false);
                spawnObject.Add(_obj);
            }
            if (_obj.name == "Projectile")
            {
                projectile = _obj;
                _obj.SetActive(false);
                spawnObject.Add(_obj);
            }
        }
        Invoke("SpawnAnObject", Random.Range(3f, maxSpawnTiming));
    }
    void SpawnAnObject()
    {
        GameObject _obj = spawnObject[Random.Range(0, spawnObject.Count)];
        if(_obj.activeSelf) 
        {
            GameObject _newObj = Instantiate(_obj);
            float theDistanceToSpawn = _obj.GetComponent<SpawnObjects>().DistanceToSpawn;
            _newObj.transform.position = new Vector2(_newObj.transform.position.x, theDistanceToSpawn);
            _newObj.GetComponent<SpawnObjects>().DistanceToSpawn = theDistanceToSpawn;
        }
        else
        {
            _obj.SetActive(true);
            if(_obj.tag == "Projectile")
            {
                _obj.GetComponent<ProjectileSpawned>().RandomSpawn();
            }
            _obj.transform.position = new Vector2(_obj.transform.position.x, _obj.GetComponent<SpawnObjects>().DistanceToSpawn);
        }
        Invoke("SpawnAnObject", Random.Range(3f, maxSpawnTiming));
    }
}
