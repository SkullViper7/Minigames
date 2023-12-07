using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebindUI : MonoBehaviour
{
    List<GameObject> UIToRebind = new List<GameObject>();
    GameObject actualUI;
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject item in FindObjectsOfType<GameObject>())
        {
            if (item.name == "Quiz" || item.name == "SlimeJump" || item.name == "RocketRide" || item.name == "BTBloc") 
            {
                UIToRebind.Add(item);
                item.SetActive(false);
            }
        }
    }

    public Object[] SearchAllButton(string _UIName)
    {
        ChangeUIToVIew(_UIName);
        Object[] allButton = FindObjectsOfType<Button>();
        foreach (Button button in allButton) 
        {
            button.onClick.AddListener(delegate { ButtonClicked(button.name); } );
        }
        return allButton;
    }


    void ChangeUIToVIew(string _UIName)
    {
        if (actualUI != null)
        {
            actualUI.SetActive(false);
        }
        foreach (GameObject ui in UIToRebind)
        {
            if (ui.name == _UIName)
            {
                ui.SetActive(true);
                actualUI = ui;
            }
        }
    }

    void ButtonClicked(string _buttonName)
    {
        Debug.Log(_buttonName);
        RebindManager.Instance.rebind.TheActionToRebind(_buttonName);
    }
}
