using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.Animations;

public class UIPage : MonoBehaviour
{
    public TextMeshProUGUI _TextEarly;
    public TextMeshProUGUI _PlayerDeadUI;
    public TextMeshProUGUI _LastDead;
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

    IEnumerator StopDeadUI(GameObject _lastDeadUI)
    {
        yield return new WaitForSeconds(2f);
        _lastDeadUI.SetActive(false);
    }
}
