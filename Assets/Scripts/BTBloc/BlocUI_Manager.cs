using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlocUI_Manager : MonoBehaviour
{
    BTBloc_Manager blocManager;
    public TMP_Text _uiTimer;

        //Singleton
    private static BlocUI_Manager _instance = null;
    private BlocUI_Manager() { }
    public static BlocUI_Manager Instance => _instance;
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

    void Start()
    {
        blocManager = GameObject.Find("Game Manager").GetComponent<BTBloc_Manager>();
    }

    public void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        _uiTimer.text = string.Format("{00}", seconds);
    }
}
