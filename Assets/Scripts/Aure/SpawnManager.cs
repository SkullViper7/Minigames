using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    private static SpawnManager _instance = null;
    public static SpawnManager Instance => _instance;

    public GameObject wall;
    public GameObject projectile;
    public GameObject arrowIndicator;
    public GameObject coin;
    public List<GameObject> spawnObject = new List<GameObject>();

    public float maxSpawnTiming;
    public float maxCoinSpawnTiming;
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
        maxCoinSpawnTiming = 3;
        UIPage _UI = SlimeJumpManager.Instance.UI;
        foreach (GameObject _obj in FindObjectsOfType(typeof(GameObject)))
        {
            switch (_obj.name)
            {
                case "Wall":
                    wall = _obj;
                    _obj.SetActive(false);
                    spawnObject.Add(_obj);
                    break;
                case "Projectile":
                    projectile = _obj;
                    _obj.SetActive(false);
                    spawnObject.Add(_obj);
                    break;
                case "ArrowIndicator":
                    arrowIndicator = _obj;
                    _obj.transform.parent.gameObject.SetActive(false);
                    break;
                case "AudioSource":
                    TimeManager.Instance.music = _obj.GetComponent<AudioSource>();
                    break;
                case "TextEarly":
                    _UI._TextEarly = _obj.GetComponent<TextMeshProUGUI>();
                    StartCoroutine(_UI.AnnounceTheGame());
                    break;
                case "TextDeadPlayer":
                    _UI._PlayerDeadUI = _obj.GetComponent<TextMeshProUGUI>();
                    _obj.SetActive(false);
                    break;
                case "Coin":
                    coin = _obj;
                    _obj.SetActive(false);
                    break;
            }
        }
    }
    public void SpawnAnObject()
    {
        GameObject _obj = spawnObject[Random.Range(0, spawnObject.Count)];
        GameObject theObjectSpawn = _obj;
        if(_obj.activeSelf) 
        {
            GameObject _newObj = Instantiate(_obj);
            theObjectSpawn = _newObj;
            float theDistanceToSpawn = _obj.GetComponent<SpawnObjects>().DistanceToSpawn;
            _newObj.transform.position = new Vector2(_newObj.transform.position.x, theDistanceToSpawn);
            _newObj.GetComponent<SpawnObjects>().DistanceToSpawn = theDistanceToSpawn;
        }
        else
        {
            _obj.SetActive(true);
            _obj.transform.position = new Vector2(_obj.transform.position.x, _obj.GetComponent<SpawnObjects>().DistanceToSpawn);
        }
        if (_obj.tag == "Projectile")
        {
            theObjectSpawn.GetComponent<ProjectileSpawned>().RandomSpawn();
            theObjectSpawn.SetActive(false);
            arrowIndicator.transform.parent.gameObject.SetActive(true);
            arrowIndicator.transform.position = new Vector2(theObjectSpawn.transform.position.x, arrowIndicator.transform.parent.position.y);
            StartCoroutine(ShowIndicatorBeforeSpawn(theObjectSpawn));
        }
        InvokeTheSpawn("SpawnAnObject", maxSpawnTiming);
    }

    IEnumerator ShowIndicatorBeforeSpawn(GameObject ProjectileSpawned)
    {
        yield return new WaitForSeconds(0.6f);
        arrowIndicator.transform.parent.gameObject.SetActive(false);
        ProjectileSpawned.SetActive(true);
        StartCoroutine(SoundArrow(ProjectileSpawned.GetComponent<AudioSource>()));
    }
    IEnumerator SoundArrow(AudioSource sound)
    {
        yield return new WaitForSeconds(0.5f);
        sound.Play();
    }

    public void InvokeTheSpawn(string _functionName, float timing)
    {
        Invoke(_functionName, Random.Range(3f, timing));
    }

    public void SpawnCoins()
    {
        GameObject theObjectSpawn = coin;
        if (coin.activeSelf)
        {
            GameObject _newCoin = Instantiate(coin);
            float theDistanceToSpawn = coin.GetComponent<SpawnObjects>().DistanceToSpawn;
            _newCoin.transform.position = new Vector2(_newCoin.transform.position.x, theDistanceToSpawn);
            _newCoin.GetComponent<SpawnObjects>().DistanceToSpawn = theDistanceToSpawn;
            theObjectSpawn = _newCoin;
        }
        else
        {
            coin.SetActive(true);
            coin.transform.position = new Vector2(coin.transform.position.x, coin.GetComponent<SpawnObjects>().DistanceToSpawn);
        }
        theObjectSpawn.GetComponent<CoinSpawned>().RandomSpawn();
        InvokeTheSpawn("SpawnCoins", maxCoinSpawnTiming);
    }
}
