using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RebindUI : MonoBehaviour
{
    public List<GameObject> UIToRebind = new List<GameObject>();
    GameObject actualUI;
    public GameObject waitingForInputObject;

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

    //Va  rechercher tout les boutons présents dans la scène pour leur donner une fonction de rebind, en excluant tout les autres boutons
    public Object[] SearchAllButton(string _UIName)
    {
        Debug.Log(_UIName);
        ChangeUIToVIew(_UIName);
        Object[] allButton = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allButton) 
        {
            if(obj.GetComponent<Button>() != null && obj.name != "LeftArrow" && obj.name != "RightArrow" && obj.name != "BackButton")
            {
                obj.GetComponent<Button>().onClick.AddListener(delegate { ButtonClicked(obj.name, obj.GetComponent<Button>()); });
            }
            if (obj.name == "WaitingForInputObject")
            {
                RebindManager.Instance.rebind.waitingForInputObject = obj;
                obj.SetActive(false);
            }
        }
        return allButton;
    }

    //Il y a 4 pages présents pour l'ui, permet de n'en garder qu'une seule lié à la page que l'on veut changer
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

    //Va rebind une touche si on touche au bouton
    void ButtonClicked(string _buttonName, Button _button)
    {
        Debug.Log(_buttonName);
        RebindManager.Instance.rebind.TheActionToRebind(_buttonName, _button);
    }
    
   
}
