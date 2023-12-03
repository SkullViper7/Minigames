using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIPage : MonoBehaviour
{
    public TextMeshProUGUI _TextEarly;
    public TextMeshProUGUI _PlayerDeadUI;
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
        _PlayerDeadUI.text = player.name + "is OUT";
    }
}
