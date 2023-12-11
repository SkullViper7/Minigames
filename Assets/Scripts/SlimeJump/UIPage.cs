using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIPage : MonoBehaviour
{
    public TextMeshProUGUI _TextEarly;
    public TextMeshProUGUI _PlayerDeadUI;
    public TextMeshProUGUI _LastDead;

    public List<GameObject> UIPodium = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        FindAnyObjectByType(typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Lance un d�compte avant de d�buter le jeu
    public IEnumerator AnnounceTheGame()
    {
        _TextEarly.text = "3";
        yield return new WaitForSeconds(1f);
        _TextEarly.text = "2";
        yield return new WaitForSeconds(1f);
        _TextEarly.text = "1";
        yield return new WaitForSeconds(1f);
        _TextEarly.text = "GO";
        SlimeJumpManager.Instance.StartTheGame();
        yield return new WaitForSeconds(1f);
        _TextEarly.gameObject.SetActive(false);
    }

    //Montre quel joueur est mort via l'ui
    public void ChangeNamePlayerDeadUI(GameObject player)
    {
        if(_LastDead != null) 
        {
            _LastDead.gameObject.SetActive(false);
        }
        _LastDead = Instantiate(_PlayerDeadUI, _PlayerDeadUI.transform.parent);
        _LastDead.text = player.name + " is OUT";
        _LastDead.gameObject.SetActive(true);
        StartCoroutine(StopDeadUI(_LastDead.gameObject));
    }

    //Montre quel joueur a surv�cu le plus longtemps via l'ui
    public void ShowNameWinnerUI(GameObject player)
    {
        if (_LastDead != null)
        {
            _LastDead.gameObject.SetActive(false);
        }
        _LastDead = Instantiate(_PlayerDeadUI, _PlayerDeadUI.transform.parent);
        _LastDead.text = player.name + " WIN!!!!!!!!!!";
        _LastDead.gameObject.SetActive(true);
        StartCoroutine(StopDeadUI(_LastDead.gameObject));
    }

    //Permet d'enlever l'ui apr�s un d�lai
    IEnumerator StopDeadUI(GameObject _lastDeadUI)
    {
        yield return new WaitForSeconds(2f);
        _lastDeadUI.SetActive(false);
    }

    //Va montrer l'ui du podium et va enregistrer le score de chaque joueur dans le leaderboard
     public void ShowPodium()
    {
        foreach (GameObject obj in UIPodium)
        {
            obj.SetActive(true);
            int _lastDead = 0;
            
            switch (obj.name) 
            {
                case "FirstPlayer":
                    obj.transform.parent.parent.gameObject.SetActive(true);
                    if (MainLeaderboardManager.Instance.IsTheBestScore(SlimeJumpManager.Instance._playersDead[0]._score))
                    {
                        Debug.Log(SlimeJumpManager.Instance._playersDead[0]._score);
                    } 
                    break;
                case "SecondPlayer":
                    _lastDead = 1;
                    break;
                case "ThirdPlayer":
                    _lastDead = 2;
                    break;
                case "LastPlayer":
                    _lastDead = 3;
                    break;
            }
            PlayerMovement _player = SlimeJumpManager.Instance._playersDead[_lastDead];
            switch (_player.name)
            {
                case "Player1":
                    MainLeaderboardManager.Instance.UpdateFloatScore("SlimeJumpPlayer1", (_player._score));
                    break;
                case "Player2":
                    MainLeaderboardManager.Instance.UpdateFloatScore("SlimeJumpPlayer2",(_player._score));
                    break;
                case "Player3":
                    MainLeaderboardManager.Instance.UpdateFloatScore("SlimeJumpPlayer3", (_player._score));
                    break;
                case "Player4":
                    MainLeaderboardManager.Instance.UpdateFloatScore("SlimeJumpPlayer4", (_player._score));
                    break;
            }
            foreach (Transform child in obj.transform)
            {
                if(child.name == "Score")
                {
                    child.GetComponent<TextMeshProUGUI>().text = _player._score + "";
                }
            }
            obj.GetComponent<Image>().sprite = _player._playerSprite;
        }
    }
}
