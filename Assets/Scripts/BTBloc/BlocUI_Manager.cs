using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlocUI_Manager : MonoBehaviour
{
    BTBloc_Manager blocManager;
    public TMP_Text _uiTimer;

    private BlocUI_Manager _uiInstance;

    public BlocUI_Manager Instance
    {
        get
        {
            if (_uiInstance == null)
            {
                Debug.LogError("Game Manager missing");
            }
            return _uiInstance;
        }
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
