using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class RebindManager : MonoBehaviour
{
    //Singleton
    private static RebindManager _instance = null;
    public static RebindManager Instance => _instance;
    //

    public PlayerInput playerInput;
    public TMP_Dropdown dropDown;
    private RebindUI rebindUI;
    public Rebind rebind;
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
        
        playerInput = GetComponent<PlayerInput>();
        rebindUI = GetComponent<RebindUI>();
        rebind = GetComponent<Rebind>();
    }

    //Permet de Montrer les touches sur les boutons en fonction du jeu choisi
    public void ChangeTheMap(string _mapName)
    {
        Object[] _allButton = rebindUI.SearchAllButton(_mapName);
        playerInput.SwitchCurrentActionMap(_mapName);
        rebind.InitBindToButton();

    }
}
