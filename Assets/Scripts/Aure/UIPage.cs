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

    IEnumerator StopDeadUI(GameObject _lastDeadUI)
    {
        yield return new WaitForSeconds(2f);
        _lastDeadUI.SetActive(false);
    }

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
